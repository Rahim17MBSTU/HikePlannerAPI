using WebAPIproject.Models.Domain;

namespace WebAPIproject.Models.DTOs
{
    public class WalkDTO
    {
        
         public Guid Id { get; set; }
         public string Name { get; set; }
         public double Length { get; set; }
         public string Description { get; set; }
         public string? WalkImageUrl { get; set; }
        
         public RegionDTO Region { get; set; }
         public DifficultyDTO Difficulty { get; set; }



    }
}
