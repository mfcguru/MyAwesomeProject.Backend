using MyAwesomeProject.Api.Helpers;
using MyAwesomeProject.AutoMapper;
using MyAwesomeProject.Data;
using MyAwesomeProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;

namespace MyAwesomeProject.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			AutoMapperConfiguration.Configure();
		}

		public IConfiguration Configuration { get; }		

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			ConfigureMiddlewareServices(services);
			ConfigureDependencyInjection(services);			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, ILoggerProvider loggerProvider)
		{
			app.ConfigureExceptionHandler(loggerProvider.CreateLogger("default"));
			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());
			app.UseAuthentication();
			app.UseSwagger();
			app.UseSwaggerUI();
			app.UseMvc();
		}

		private void ConfigureMiddlewareServices(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection("AppSettings");
			var appSettings = appSettingsSection.Get<AppSettings>();
			services.Configure<AppSettings>(appSettingsSection);

			services.AddCors();
			services.AddJwtAuthentication(appSettings.Secret);
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new Info { Title = "Jabit!", Version = "v1" });
				c.AddSecurityDefinition("Bearer",
					new ApiKeyScheme
					{
						In = "header",
						Description = "Please enter into field the word 'Bearer' following by space and JWT",
						Name = "Authorization",
						Type = "apiKey"
					});
				c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
					{ "Bearer", Enumerable.Empty<string>() },
				});
			});
			services.AddDbContextPool<DataContext>(context => context
				.UseLazyLoadingProxies()
				.UseSqlServer(appSettings.ConnectionString));
		}

		private void ConfigureDependencyInjection(IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();			
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IAuthorService, AuthorService>();
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<ICategoryService, CategoryService>();
			
		}
	}
}
