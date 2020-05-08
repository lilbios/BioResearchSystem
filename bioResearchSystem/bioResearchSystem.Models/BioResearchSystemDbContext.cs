using bioResearchSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bioResearchSystem.Mode
{
    public class BioResearchSystemDbContext : IdentityDbContext<User>
    {
        public DbSet<Research> Researches { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public BioResearchSystemDbContext(DbContextOptions<BioResearchSystemDbContext> options)
            :base(options)
        {

            
        }
    }
    public class BioResearhSystemDbContextFactory : IDesignTimeDbContextFactory<BioResearchSystemDbContext>
    {
        public BioResearchSystemDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BioResearchSystemDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BRSdb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("bioResearchSystem.Models"));
            return new BioResearchSystemDbContext(optionBuilder.Options);
        }
    }
}
