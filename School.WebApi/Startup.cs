using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using School.Repository.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace School.WebApi
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
            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddCors();
            services.AddScoped<ISRepository, SRepository>();
            services.AddScoped<SContext>();
          //  services.AddSwaggerGen();
           // services.AddAutoMapper();


            services.AddDbContext<SContext>(
                _mySql => _mySql.UseMySql(Configuration.GetConnectionString("DbSchool"),
                _mig => _mig.MigrationsAssembly("School.WebApi")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(_cors => _cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"resources")),
                RequestPath = new PathString("/resources")
            });

      //   app.UseSwagger();
      //   app.UseSwaggerUI(c =>
      //   {
      //       c.SwaggerEndpoint("api/swagger/v1/swagger.json", "School API");
      //       c.RoutePrefix = string.Empty;

      //     });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
