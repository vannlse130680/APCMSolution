
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APCMSolution.Data.EF
{
    class APCMDbContextFactory : IDesignTimeDbContextFactory<APCMDbContext>
    {
        public APCMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder() // tạo đối tượng conf
                .SetBasePath(Directory.GetCurrentDirectory()) //FileExtensions // add thư mục hiện tại .data làm thư mục gốc
                .AddJsonFile("appsettings.json") // Json
                .Build();
            var connectionStrings = configuration.GetConnectionString("APCMSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<APCMDbContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            return new APCMDbContext(optionsBuilder.Options);
        }
    }
}
