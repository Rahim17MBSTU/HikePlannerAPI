using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIproject.Models.Domain;
using WebAPIproject.Models.DTOs;
using WebAPIproject.Repositories.Interfaces;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        //Get all walk
        //GET: /api/Walks?filterOn=Name&filterQuery=Value&sortBy=name&isAsending=true
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            var walks = await _walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending?? true);
            if (walks == null)
            {
                return NotFound();
            }
            // map domain model to DTO 

            return Ok(_mapper.Map<List<WalkDTO>>(walks));
        }
        //Create Walk
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalksDTO createWalksDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //map DTO to Domain model
            var walkDomainModel = _mapper.Map<Walk>(createWalksDTO);
            walkDomainModel = await _walkRepository.CreateAsync(walkDomainModel);

            //Map domain to DTO
            var walkDTO = _mapper.Map<WalkDTO>(walkDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = walkDTO.Id }, walkDTO);
        }

        //GetById 
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //convert Domain model to DTO
            var walkDTO =  _mapper.Map<WalkDTO>(walkDomainModel);
            return Ok(walkDTO);
        }

        // update 
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDTO updateWalkDTO) // which property we want to expose from user so we use DTO class
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // map DTO to Domain model (Client) -> (DTO) -> API -> (Domain Model) -> database
            //                                                        ^
            //                                       |                | 
            //                                       ------------------
            //map DTO to Domain model
            var walkDomainModel = _mapper.Map<Walk>(updateWalkDTO); // apply automapping
            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain model to DTO
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));

        }

        //Delete method
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {

           var deleteWalkDomain =  await _walkRepository.DeleteAsync(id);
           if(deleteWalkDomain == null)
           {
                return NotFound();
           }
           //return deleted object as DTO
           return Ok(_mapper.Map<WalkDTO>(deleteWalkDomain))
;        } 
    }
}
