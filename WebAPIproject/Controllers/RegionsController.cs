using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIproject.Data;
using WebAPIproject.Models.Domain;
using WebAPIproject.Models.DTOs;
using WebAPIproject.Repositories.Interfaces;

namespace WebAPIproject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper ) 
        {
            //_context = context;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from database - domain model
            var regionsDomain = await _regionRepository.GetAllAsync();
            //map domain model to DTO

            var regionDto = _mapper.Map<List<RegionDTO>>(regionsDomain); // Here we apply auto-mapping
           
            //return DTO model
            return Ok(regionDto);
        }

        //GET single Regions by id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //get region Domain model from database
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            
            
            if(regionDomain == null)
            {
                return NotFound();
            }

            // Map/ convert region Domain model to Region dto
            var regionDto = _mapper.Map<RegionDTO>(regionDomain);

            // return DTO to client
            return Ok(regionDto);
        }

        //Post to Create New Region
        //Post: https://localhost:portnumber/api/regions/{id}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDTO createRegionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // convert DTO to Domain Model
            var regionDomainModel = _mapper.Map<Region>(createRegionDTO);

            //use domain model to create region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            // map domain model back to DTO
            var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new {id = regionDTO.Id}, regionDTO);

        }

        //update Region
        //PUT: https://localhost:posrtnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //map Dto to domain model
            var regionDomainModel = _mapper.Map<Region>(updateRegionDTO);
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // convert domain model to dto
            var regionDto = _mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);
        }

        //Delete Region
        // Delete : https://localhost:portnumber/api/Regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            
            if(regionDomainModel == null)
            {
                return NotFound();
            }


            // return deleted region back
            var regionDto = _mapper.Map<RegionDTO>(regionDomainModel);
            return Ok(regionDto);
        }

    }
}
