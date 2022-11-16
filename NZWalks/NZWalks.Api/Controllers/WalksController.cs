using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var Walks = await walkRepository.GetAllAsync();
            var WalksDTO = mapper.Map<List<Models.Dto.Walk>>(Walks);
            return Ok(WalksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await walkRepository.GetAsync(id);

            if (walk is null) return NotFound();

            var dto = mapper.Map<Models.Dto.Walk>(walk);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.Dto.AddWalkRequest walkRequest)
        {
            //1) Request to domain model
            var walk = mapper.Map<Models.Domain.Walk>(walkRequest);
            //2) Pass details to repository
            walk = await walkRepository.AddAsync(walk);
            //3) Convert back to dto
            var responseWalk = mapper.Map<Models.Dto.Walk>(walk);
            //4) response
            return CreatedAtAction(nameof(GetWalkAsync), new { id = responseWalk.Id }, responseWalk);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {                                 
            var walk = await walkRepository.DeleteAsync(id);
            if (walk is null) return NotFound();            
            var responseWalk = mapper.Map<Models.Dto.Walk>(walk);
            return Ok(responseWalk);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.Dto.UpdateWalkRequest walkRequest)
        {
            //1) Request to domain model
            var walk = mapper.Map<Models.Domain.Walk>(walkRequest);

            //2) Pass details to repository
            walk = await walkRepository.UpdateAsync(id, walk);
            if (walk is null) return NotFound();

            //3) Convert back to dto
            var responseWalk = mapper.Map<Models.Dto.Walk>(walk);

            //4) response
            return Ok(responseWalk);            
        }
    }
}
