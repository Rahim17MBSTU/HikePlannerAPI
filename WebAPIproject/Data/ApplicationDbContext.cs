using Microsoft.EntityFrameworkCore;
using WebAPIproject.Models.Domain;

namespace WebAPIproject.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties (Easy, medium, hard)
            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("deb63431-68ef-4bb9-8227-cf622fb85898"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("71dbe6ef-ceb7-4439-bbf7-91a4fb825d7e"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("f36123ab-783f-4935-97f0-f56044fd24b6"),
                    Name = "Hard"
                }
            };
            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id= Guid.Parse("914f6866-04c1-4f80-9579-5fc9882458ed"),
                    Name = "Sundarban",
                    Code = "Khu",
                    RegionImageUrl = "https://encrypted-tbn3.gstatic.com/licensed-image?q=tbn:ANd9GcTlnqro3eX6Ak-C2QJzU4DGaMnXz-NgY4J1XsEDJHNnpOsYpHG-yHM-YB0TXZsBP_-kYi5L89nwHzRS1DufiOx4NESb8OoTInde00T4hQ"

                },
                new Region
                {
                    Id= Guid.Parse("b1bebf72-7ef5-4e0f-89de-88fc60f979cc"),
                    Name = "Sundarban",
                    Code = "Khu",
                    RegionImageUrl = null

                },
                new Region
                {
                    Id= Guid.Parse("66a9b33f-87a9-4697-b99a-87e7ffe1fd8c"),
                    Name = "Cox-bazar Sea beach",
                    Code = "Cox",
                    RegionImageUrl = null

                },

            };

            modelBuilder.Entity<Region>().HasData(regions);


            
        }
    }
}
