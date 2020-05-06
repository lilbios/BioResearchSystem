using bioResearchSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bioResearchSystem.Context
{
    public class BioResearchSystemDbContext : IdentityDbContext<User>
    {
        public DbSet<Research> Researches { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public BioResearchSystemDbContext(DbContextOptions<BioResearchSystemDbContext> options)
            :base(options)
        {

            Database.EnsureCreated();
        }





    }
}
