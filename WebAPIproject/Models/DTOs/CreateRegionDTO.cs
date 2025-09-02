using System.ComponentModel.DataAnnotations;

namespace WebAPIproject.Models.DTOs
{
    public class CreateRegionDTO
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code has to be a minimum 3 character.")]
        [MaxLength(3,ErrorMessage = "Code has to be a Maximum 3 character.")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Name can be maximum 100 character")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
