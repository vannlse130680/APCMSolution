using APCMSolution.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APCMSolution.Data.EF
{
    public class APCMDbContext : DbContext
    {
        public APCMDbContext()
        {
        }

        public APCMDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
    }
}
