using LearningApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Use your database provider and connection string here
            optionsBuilder.UseSqlServer("Server=LAPTOP-FEEODUUR;Database=LearningAppDb;TrustServerCertificate=True;Trusted_Connection=True");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
