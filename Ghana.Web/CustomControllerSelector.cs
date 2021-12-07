using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace Ghana.Web
{
    public class CustomControllerSelector : IHttpControllerSelector
    {
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controller;
        private readonly HttpConfiguration _config;

        public CustomControllerSelector(HttpConfiguration config)
        {
            _controller = new Lazy<Dictionary<string, HttpControllerDescriptor>>(Initialize_Controller_Dictionary);
            _config = config;
        }
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, HttpControllerDescriptor> Initialize_Controller_Dictionary()
        {
            var Dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            var Assemblies_Resolver = _config.Services.GetAssembliesResolver();
            var Controller_Resolver = _config.Services.GetHttpControllerTypeResolver();

            var Controller_Types = Controller_Resolver.GetControllerTypes(Assemblies_Resolver);

            foreach (var ct in Controller_Types)
            {
                var Segments = ct.Namespace.Split(Type.Delimiter);

                var Controller_Name = ct.Name.Remove(ct.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);

                var Controller_Key = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", Segments[Segments.Length - 1], Controller_Name);


                if (Dictionary.Keys.Contains(Controller_Key) == false)
                {
                    Dictionary[Controller_Key] = new HttpControllerDescriptor(_config, ct.Name, ct);
                }
            }

            return Dictionary;
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var request_data = request.GetRouteData();
            if (request_data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var Controller_Name = Get_Controller_Name(request_data);
            if (Controller_Name == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var Name_Space = Get_Version(request_data);
            if (Name_Space == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var Controller_Key = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", Name_Space, Controller_Name);

            HttpControllerDescriptor Descriptor;
            if (_controller.Value.TryGetValue(Controller_Key, out Descriptor))
            {
                var subRoutes = request_data.GetSubRoutes();
                IEnumerable<IHttpRouteData> filteredSubRoutes = subRoutes.Where(attrRouteData =>
                {
                    HttpControllerDescriptor currentDescriptor = ((HttpActionDescriptor[])request_data.Route.DataTokens["actions"]).First().ControllerDescriptor;
                    return currentDescriptor != null && currentDescriptor.ControllerName.Equals(Descriptor.ControllerName, StringComparison.OrdinalIgnoreCase);
                });
                request_data.Values["MS_SubRoutes"] = filteredSubRoutes.ToArray();
                return Descriptor;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        private T Get_Route_Variable<T>(IHttpRouteData Route_Data, string Name)
        {
            object Result;

            if (Route_Data.Values.TryGetValue(Name, out Result))
            {
                return (T)Result;
            }

            return default(T);
        }
        private string Get_Version(IHttpRouteData Route_Data)
        {
            var Sub_Route_Data = Route_Data.GetSubRoutes().FirstOrDefault();
            if (Sub_Route_Data == null)
            {
                return null;
            }

            return Get_Route_Variable<string>(Sub_Route_Data, "apiVersion");
        }

        private string Get_Controller_Name(IHttpRouteData Route_Data)
        {

            var SubRoute = Route_Data.GetSubRoutes().FirstOrDefault();

            if (SubRoute == null)
            {
                return null;
            }

            var Data_Token_Value = SubRoute.Route.DataTokens.First().Value;
            if (Data_Token_Value == null)
            {
                return null;
            }


            var Controller_Name = ((HttpActionDescriptor[])Data_Token_Value).First().ControllerDescriptor.ControllerName.Replace("Controller", string.Empty);


            return Controller_Name;
        }
    }
}
