using AutoMapper;
using Ghana.Web.Models;
using Ghana.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Web.Controllers
{
    public class PopulationController : Controller
    {
        public IPopulationService _populationService;
        public readonly IMapper _mapper;

        public PopulationController(IPopulationService service,IMapper mapper)
        {
            _populationService = service;
            _mapper = mapper;
        }
        public async Task<ActionResult> PopulationIndex()
        {
            var result = await _populationService.GetAllPopulationInfoAsync<List<PopulationLiteDTO>>();
            if(result.Any())
            {

            }
            return View(result);
        }

        [HttpPost("Add-New")]
        public async Task<ActionResult> PopulationAdd([FromBody] PopulationAddDTO populationAdd)
        {
            var result = await _populationService.AddPopulationInfoAsync<List<PopulationAddDTO>>(_mapper.Map<Population>(populationAdd));
            return View(result);
        }
    }
}
