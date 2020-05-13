using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CompanyProvider.API.Filters;
using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Domain.Interfaces.Services;
using CompanyProvider.Infrastructure.Context;
using CompanyProvider.Infrastructure.Repositories;
using CompanyProvider.Service.Services;

namespace CompanyProvider.API
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
            services.AddControllersWithViews(options => 
                options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddDbContext<CompanyProviderContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICompanyRepository<Company>, CompanyRepository<Company>>();
            services.AddScoped<ICompanyProviderRepository<Domain.Entities.CompanyProvider>, CompanyProviderRepository<Domain.Entities.CompanyProvider>>();
            services.AddScoped<IContactRepository<Contact>, ContactRepository<Contact>>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyProviderService, CompanyProviderService>();
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
                app.UseExceptionHandler("/Home/Error");
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
