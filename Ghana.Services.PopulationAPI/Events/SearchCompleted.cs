using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Events
{
    public class SearchCompleted :Event
    {
        public object Data { get; set; }
    }
}
