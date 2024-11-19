using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<PortfolioItem>().HasData(
                new PortfolioItem
                {
                    Id = 1,
                    Title = "Portfolio Project",
                    Description = "Sample Description",
                    ImageUrl = "https://via.placeholder.com/300",
                    Url = "https://github.com/YourGithubProfile/Project"
                }
            );
        }




        
        public static void SeedData(ApplicationDbContext context)
        {
            
            if (!context.PortfolioItems.Any())
            {
                var initialPortfolioItems = new List<PortfolioItem>
                {
                    new PortfolioItem
                    {
                        Title = "Project 1",
                        Description = "This is a description of Project ONE.",
                        ImageUrl = "/project-1.jpg"
                    },
                    new PortfolioItem
                    {
                        Title = "Project 2",
                        Description = "This is a description of Project TWO.",
                        ImageUrl = "/project-2.jpg"
                    },
                    new PortfolioItem
                    {
                        Title = "Project 3",
                        Description = "This is a description of Project THREE.",
                        ImageUrl = "/project-3.jpg"
                    }
                };

                
                context.PortfolioItems.AddRange(initialPortfolioItems);
                context.SaveChanges();
            }
        }
    }
}
