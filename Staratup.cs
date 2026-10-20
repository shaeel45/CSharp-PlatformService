using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using PlatformServices.Data;

namespace PlatformServices
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
            services.AddScoped<IPlatformRepo, PlatformRepo>();
			services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(static c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Platform Services", Version = "v1" });
            });
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
            PrepDb.PrepPopulation(app);
		}
	}
}
