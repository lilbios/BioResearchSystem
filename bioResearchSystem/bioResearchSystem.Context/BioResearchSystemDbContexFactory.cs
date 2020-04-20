using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Context
{
    public class BioResearchSystemDbContexFactory : IDesignTimeDbContextFactory<BioResearchSystemDbContex>
    {
        public BioResearchSystemDbContex CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BioResearchSystemDbContex>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=eventodb;Trusted_Connection=True;MultipleActiveResultSets=true", 
                b => b.MigrationsAssembly(typeof(BioResearchSystemDbContexFactory).Assembly.GetName().Name));
            return new BioResearchSystemDbContex(optionBuilder.Options);
        }
    }
}
