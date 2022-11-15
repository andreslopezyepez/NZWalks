﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<Models.Dto.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region is null) return NotFound();

            var dto = mapper.Map<Models.Dto.Region>(region);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync([FromBody] Models.Dto.AddRegionRequest regionRequest)
        {
            //1) Request to domain model
            var region = mapper.Map<Models.Domain.Region>(regionRequest);
            //2) Pass details to repository
            region = await regionRepository.AddAsync(region);
            //3) Convert back to dto
            var responseRegion = mapper.Map<Models.Dto.Region>(region);
            //4) response
            return CreatedAtAction(nameof(GetRegionAsync), new { id = responseRegion.Id }, responseRegion);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {                                 
            var region = await regionRepository.DeleteAsync(id);
            if (region is null) return NotFound();            
            var responseRegion = mapper.Map<Models.Dto.Region>(region);
            return Ok(responseRegion);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.Dto.UpdateRegionRequest regionRequest)
        {
            //1) Request to domain model
            var region = mapper.Map<Models.Domain.Region>(regionRequest);

            //2) Pass details to repository
            region = await regionRepository.UpdateAsync(id, region);
            if (region is null) return NotFound();

            //3) Convert back to dto
            var responseRegion = mapper.Map<Models.Dto.Region>(region);

            //4) response
            return Ok(responseRegion);            
        }
    }
}
