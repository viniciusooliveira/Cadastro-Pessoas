using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CrossCutting.Settings;
using Domain.Contexts.Contracts;
using FluentValidation.AspNetCore;
using Mariadb.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SimpleInjector.Lifestyles;
using Container = IOC.Container;
namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly string _corsName = "UI";
        
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Container.Init();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv => 
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });
            
            services.AddCors(options =>
            {
                options.AddPolicy(
                    _corsName,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            });
            
            Container.InitServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_corsName);
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            Container.InitRegisters(Configuration.GetSection("AppSettings").Get<AppSettings>());

            Container.InitApplication(app);
            
            MigrateDatabase();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private void MigrateDatabase()
        {
            using (var scope = AsyncScopedLifestyle.BeginScope(Container.GetContainer()))
            {
                //Migração do banco de dados
                var context = (WebpicContext) scope.GetInstance<IWebpicContext>();
                context.Database.Migrate();
            }
        }
    }
}