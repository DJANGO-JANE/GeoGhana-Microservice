using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Application.Features.SupplyRegionData
{
    public class SearchCompleted :Event
    {
        public object Data { get; set; }


        public SearchCompleted(object data)
        {
            Data = data;
        }
    }
}
