using bioResearchSystem.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Context
{
    public class BioResearchSystemDbContex:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Research> Researches { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Device> Devices { get; set; }

        public BioResearchSystemDbContex(DbContextOptions<BioResearchSystemDbContex> options)
            :base(options)
        {

        }

    }
}
