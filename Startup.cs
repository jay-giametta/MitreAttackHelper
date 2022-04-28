using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MitreAttackHelper.Repository;
using MitreAttackHelper.Services.Mitre;

namespace MitreAttackHelper
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddWebOptimizer(optimizer =>
            {
                optimizer.MinifyCssFiles("css/mitre-attack-helper.css");
                optimizer.MinifyJsFiles("js/mitre-attack-helper.js");
            });
            services.AddSingleton(context => new MitreContext(url: "https://raw.githubusercontent.com/mitre-attack/attack-stix-data/master/enterprise-attack/enterprise-attack.json"));
            services.AddScoped<MitreAttackPatternService>();
            services.AddScoped<MitreCollectionService>();
            services.AddScoped<MitreCourseOfActionService>();
            services.AddScoped<MitreDataComponentService>();
            services.AddScoped<MitreDataSourceService>();
            services.AddScoped<MitreIdentityService>();
            services.AddScoped<MitreIntrusionSetService>();
            services.AddScoped<MitreMalwareService>();
            services.AddScoped<MitreMarkingDefinitionService>();
            services.AddScoped<MitreMatrixService>();
            services.AddScoped<MitreRelationshipService>();
            services.AddScoped<MitreTacticService>();
            services.AddScoped<MitreToolService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebOptimizer();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}
