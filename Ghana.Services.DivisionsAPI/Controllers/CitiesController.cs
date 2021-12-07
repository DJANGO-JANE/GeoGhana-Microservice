﻿using AutoMapper;
using Ghana.Services.DivisionsAPI.DTOs;
using Ghana.Services.DivisionsAPI.Interfaces;
using Ghana.Services.DivisionsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Controllers
{
    /// <summary>
    /// Cities in DivisionsAPI
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {

        public readonly ICityRepository _service;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository repository, IMapper mapper)
        {
            _service = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets list of all Cities in DivisionsAPI
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityView>>> Get()
        {
            var result =await  _service.GetAllCities();

            return Ok(_mapper.Map<IEnumerable<CityView>>(result));
        }

        /// <summary>
        /// Query for City using all or part of name
        /// </summary>
        [HttpGet]
        [Route("Query")]
        public async Task<ActionResult<IEnumerable<CityView>>> SearchCityLike([FromQuery(Name = "name")]string name)
        {
            var results = await _service.QueryCityName(name);

            if(!results.Any())
            {
                return Ok(_mapper.Map<IEnumerable<CityView>>(results));
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Search City by city code
        /// </summary>
        [HttpGet("{cityCode}", Name = "SearchCity")]
        public async Task<ActionResult<CityFull>> SearchCityByName(int cityCode) 
        {
            var request = await _service.SearchCityByCode(cityCode);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CityFull>(request));
        }

        /// <summary>
        /// Add new City to DivisionsAPI
        /// </summary>
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<CityAdd>> AddCityInfo([FromBody] CityAdd cityToAdd)
        {
            var duplicate = await _service.FindDuplicate(cityToAdd.Name, cityToAdd.RegionName);
            if (duplicate == null)
            {
                var cityModel = _mapper.Map<City>(cityToAdd);

                _service.AddNewCity(cityModel);
                _service.SaveChanges();

                return Ok(); 
            }
            else
            {
                return BadRequest($"{cityToAdd.RegionName} already contains {cityToAdd.Name}.");
            }
        }

        /// <summary>
        /// Insert City to DivisionsAPI
        /// </summary>
        [HttpPut("{cityCode}")]
        public async Task<ActionResult> UpdateCityInfo(int cityCode, CityUpdate cityToUpdate)
        {
            var cityModel = await _service.SearchCityByCode(cityCode);
            if (cityModel == null)
            {
                return NotFound();
            }
            _mapper.Map(cityToUpdate, cityModel);

            _service.UpdateCity(cityModel);
            _service.SaveChanges();

            return Ok(_service.SearchCityByCode(cityCode));
        }

        /// <summary>
        /// Modify part of City information
        /// </summary>
        [HttpPatch("{cityCode}")]
        public async Task<ActionResult> PartialUpdateCity(int cityCode, JsonPatchDocument<CityUpdate> patchDoc)
        {
            var cityModel = await _service.SearchCityByCode(cityCode);
            if (cityModel == null)
            {
                return NotFound();
            }

            var cityToPatch = _mapper.Map<CityUpdate>(cityModel);
            patchDoc.ApplyTo(cityToPatch,ModelState);

            if (!TryValidateModel(cityToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cityToPatch, cityModel);
            _service.UpdateCity(cityModel);
            _service.SaveChanges();

            return Ok(_service.SearchCityByCode(cityCode));
        }

        /// <summary>
        /// Remove City from DivisionsAPI.
        /// </summary>
        [HttpDelete("{cityCode}")]
        public async Task<ActionResult> DeleteCity(int cityCode)
        {
            var cityModel = await _service.SearchCityByCode(cityCode);
            if (cityModel == null)
            {
                return NotFound();
            }

            _service.DeleteCity(cityModel);
            _service.SaveChanges();

            return NoContent();
        }

    }
}
