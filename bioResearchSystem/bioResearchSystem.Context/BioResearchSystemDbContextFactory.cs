using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace bioResearchSystem.Context
{
    /// <summary>
    /// ???
    /// </summary>
    public class BioResearchSystemDbContextFactory : IDesignTimeDbContextFactory<BioResearchSystemDbContext>
    {
        public BioResearchSystemDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BioResearchSystemDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bioresearchsystemdb;Trusted_Connection=True;MultipleActiveResultSets=true", 
                b => b.MigrationsAssembly(typeof(BioResearchSystemDbContextFactory).Assembly.GetName().Name));
            return new BioResearchSystemDbContext(optionBuilder.Options);
        }
    }
}
