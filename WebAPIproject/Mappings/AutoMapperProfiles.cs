using AutoMapper;
using WebAPIproject.Models.Domain;
using WebAPIproject.Models.DTOs;

namespace WebAPIproject.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //create Region mapping
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<CreateRegionDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionDTO, Region>().ReverseMap();
            
            //create Walks mapping
            CreateMap<CreateWalksDTO,Walk>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
            CreateMap<UpdateWalkDTO, Walk>().ReverseMap();

            //Create Difficulty mapping
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();


        }
    }
}
