using System.ComponentModel.DataAnnotations;

namespace WebAPIproject.Models.DTOs
{
    public class UpdateWalkDTO
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Maximum 100 character are allowed")]
        public string Name { get; set; }
        [Required]
        [Range(0,100)]
        public double Length { get; set; }
        [Required]
        [MaxLength(800)]
        public string Description { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
