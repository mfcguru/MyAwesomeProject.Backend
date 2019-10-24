using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MyAwesomeProject.Data
{
	public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
				.AddJsonFile("appsettings.json", optional: false)
				.AddJsonFile($"appsettings.{envName}.json", optional: false)
				.Build();

			var connectionString = configuration.GetSection("AppSettings").GetSection("ConnectionString").Value;
			var dbContextBuilder = new DbContextOptionsBuilder<DataContext>();			
			dbContextBuilder.UseSqlServer(connectionString);
			return new DataContext(dbContextBuilder.Options);
		}
	}
}
