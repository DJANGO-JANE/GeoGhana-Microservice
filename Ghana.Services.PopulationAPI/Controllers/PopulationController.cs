using AutoMapper;
using Ghana.Services.PopulationAPI.DTOs;
using Ghana.Services.PopulationAPI.Extensions;
using Ghana.Services.PopulationAPI.Models;
using Ghana.Services.PopulationAPI.Repository;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Controllers
{
    /// <summary>
    /// Information about the population in the various Administrative Divisions of Ghana
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PopulationController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected ResponseDTO _response;
        private readonly IPopulationRepository _repository;
        private readonly IMapper _mapper;

        public PopulationController(IPopulationRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        /// <summary>
        /// Get all population data from database.
        /// </summary>
        /// <returns>List of population data grouped by Region.</returns>
        [HttpGet]
        public async Task<ActionResult<List<PopulationLiteDTO>>> Get()
        {
            log.Info("All population data requested.");

                var population = await _repository.GetThePopulation();
                //_response.Result = _mapper.Map<List<RegionFullDTO>>(population);
/*            }
            catch(Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }*/
            return _mapper.Map<List<PopulationLiteDTO>>(population);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<List<RegionFullDTO>>> RetrievePopulationInformation([FromQuery] string code)
        {
            log.Info("All population data requested.");

            var population = await _repository.GetThePopulation();
            //_response.Result = _mapper.Map<List<RegionFullDTO>>(population);
            /*            }
                        catch(Exception ex)
                        {
                            _response.IsSuccessful = false;
                            _response.ErrorMessages = new List<string>() { ex.ToString() };
                        }*/
            return _mapper.Map<List<RegionFullDTO>>(population);
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<RegionFullDTO>> AddNewPopulationRecord([FromBody] PopulationAddDTO populationAdd)
        {
            log.Info("Add population data requested.");

            var _population = _mapper.Map<Population>(populationAdd);
            var popFromDb = await _repository.AddPopulationData(_population);

/*            await _repository.AddAsync<Population>(_population);

            var popFromDb = await _repository.GetPopulationData(populationAdd.DivisionCode);*/

            //_response.Result = _mapper.Map<List<RegionFullDTO>>(population);
            /*            }
                        catch(Exception ex)
                        {
                            _response.IsSuccessful = false;
                            _response.ErrorMessages = new List<string>() { ex.ToString() };
                        }*/
            return _mapper.Map<RegionFullDTO>(popFromDb);
        }
    }
}
