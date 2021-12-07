using Ghana.Web.Models;
using Ghana.Web.Services;
using Microsoft.AspNetCore.Mvc;
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

namespace Ghana.Web.Controllers
{
    public class DivisionsController : Controller
    {
        public IDivisionsService _divisionService;


        public DivisionsController(IDivisionsService service )
        {
            _divisionService = service;
        }

        public async Task<ActionResult<List<RegionView>>> Get()
        {
            var results = _divisionService.GetAllDivisionMembers<RegionView>();

            return View(results);
        }

    }
}

