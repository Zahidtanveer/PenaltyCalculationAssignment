using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using Microsoft.Extensions.Hosting;
using Veripark.Assigment.Data;
using Veripark.Assigment.Data.Repository;
using Veripark.Assigment.Data.Repository.Interfaces;
using Veripark.Assigment.Data.Services.Abstract;
using Veripark.Assigment.Data.Services.Concrete;

namespace Veripark.Assigment.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Data.ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICountryRepository, CountryRepository>();
            
            services.Add(typeof(IPenaltyCalculationService), typeof(TurkeyPenaltyCalculationService), Data.Enum.Country.TR.GetName(), ServiceLifetime.Transient);
            
            services.Add(typeof(IPenaltyCalculationService), typeof(UnitedArabEmiratesPenaltyCalculationService), Data.Enum.Country.AE.GetName(), ServiceLifetime.Transient);
            
            services.AddSingleton<IPenaltyCalculationServiceFactoryPatternResolver, PenaltyCalculationServiceFactoryPatternResolver>();
            
            services.AddSingleton<IPenaltyCalculationProcessor, PenaltyCalculationProcessor>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=PenaltyCalculation}/{action=Index}/{id?}");
            });
        }
    }
}
