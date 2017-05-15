using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class PortfolioContext : IdentityDbContext<User>
    {
        public PortfolioContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Project> Portfolio { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Portfolio;integrated security=True;");
        }
    }
}
