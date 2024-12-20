using AGPS.Core.DTOs;
using AGPS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Infrastructure.Persistance
{
    public class AGPSContext : DbContext
    {
        public AGPSContext(DbContextOptions<AGPSContext> options) : base(options) { }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<AssignmentTestCases> AssignmentTestCases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<AssignmentDTO>();
            modelBuilder.Ignore<TestCaseDTO>();
        }

    }
}
