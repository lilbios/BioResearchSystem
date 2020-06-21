using bioResearchSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bioResearchSystem.Models
{
    public class BioResearchSystemDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Research> Researches { get; set; }
        public DbSet<Experimet> Experiments { get; set; }
        
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagResearch> TagResearches { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public BioResearchSystemDbContext(DbContextOptions<BioResearchSystemDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserId);
        }
    }
    public class BioResearhSystemDbContextFactory : IDesignTimeDbContextFactory<BioResearchSystemDbContext>
    {
        public BioResearchSystemDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BioResearchSystemDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=brsdb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("bioResearchSystem.Models"));
            return new BioResearchSystemDbContext(optionBuilder.Options);
        }
    }
}
