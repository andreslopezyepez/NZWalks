using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetRegions();

            //return DTO
            //var regionsDTO = new List<Models.Dto.Region>();
            //regionsDTO.ToList().ForEach(r =>
            //{
            //    var regionDTO = new Models.Dto.Region()
            //    {
            //        Id = r.Id,
            //        Code = r.Code,
            //        Name = r.Name,
            //        Area = r.Area,
            //        Lat = r.Lat,
            //        Long = r.Long,
            //        Population = r.Population
            //    };
            //});

            var regionsDTO = mapper.Map<Models.Dto.Region>(regions);

            return Ok(regionsDTO);
        }
    }
}
