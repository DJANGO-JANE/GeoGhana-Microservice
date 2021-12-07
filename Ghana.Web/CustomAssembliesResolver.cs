using Ghana.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace Ghana.Web
{
    public class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var baseAssemblies = base.GetAssemblies().ToList();
/*            var assemblies = new List<Assembly>(baseAssemblies)
            {
                typeof(LocalitiesController).Assembly,
*//*                typeof(RegionsController).Assembly,
                typeof(CitiesController).Assembly*//*
            };
            baseAssemblies.AddRange(assemblies);*/

            return baseAssemblies.Distinct().ToList();
        }
    }
}
