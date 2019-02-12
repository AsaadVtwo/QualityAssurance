using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QualityAssurance.Models;

namespace QualityAssurance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QualityAssurance.Models.Employee> Employee { get; set; }
        public DbSet<QualityAssurance.Models.Department> Department { get; set; }
        public DbSet<QualityAssurance.Models.Division> Division { get; set; }
    }
}
