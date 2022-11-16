using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalkDifficultiesController : ControllerBase
    {
        private readonly IWalkDifficultyRepository repository;
        private readonly IMapper mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var records = await repository.GetAllAsync();
            var dto = mapper.Map<List<Models.Dto.WalkDifficulty>>(records);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var record = await repository.GetAsync(id);

            if (record is null) return NotFound();

            var dto = mapper.Map<Models.Dto.WalkDifficulty>(record);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Models.Dto.AddWalkDifficultyRequest request)
        {
            //1) Request to domain model
            var domainRecord = mapper.Map<Models.Domain.WalkDifficulty>(request);
            //2) Pass details to repository
            domainRecord = await repository.AddAsync(domainRecord);
            //3) Convert back to dto
            var dto = mapper.Map<Models.Dto.WalkDifficulty>(domainRecord);
            //4) response
            return CreatedAtAction(nameof(GetByIdAsync), new { id = dto.Id }, dto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var record = await repository.DeleteAsync(id);
            if (record is null) return NotFound();
            var dto = mapper.Map<Models.Dto.WalkDifficulty>(record);
            return Ok(dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] Models.Dto.UpdateWalkDifficultyRequest request)
        {
            //1) Request to domain model
            var domainRecord = mapper.Map<Models.Domain.WalkDifficulty>(request);

            //2) Pass details to repository
            domainRecord = await repository.UpdateAsync(id, domainRecord);
            if (domainRecord is null) return NotFound();

            //3) Convert back to dto
            var dto = mapper.Map<Models.Dto.WalkDifficulty>(domainRecord);

            //4) response
            return Ok(dto);
        }
    }
}
