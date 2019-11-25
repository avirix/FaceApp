using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Database;
using FaceDetector.Middlewares;
using FaceDetector.Services.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace FaceDetector
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
            // initialize db context
            services.AddDbContext<FaceAppDbContext>(options =>
#if DEBUG
                options.UseSqlServer(Configuration.GetConnectionString("SQLLocalConnectionString"))
#else
                options.UseSqlServer(Configuration.GetConnectionString("SQLAzureConnectionString"))
#endif
            );

            // add services to DI
            services.AddTransient<IFaceService, FaceService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "FaceApp", Description = "FaceApp documentation" });
            });

            // handle CORS policies
            services.AddCors(
                options => options.AddPolicy("AllowAllPolicy", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                )
            );

            services
                .AddControllers(options => { options.AllowEmptyInputInBodyModelBinding = true; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FaceAppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // apply automigrations
                // NOTE: context disposed in block below
                // (not available in another part of method)
                using (context)
                {
                    context.Database.Migrate();
                }
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            // add swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "FaceApp"));

            app.UseCors("AllowAllPolicy");

            app.UseApiResponse();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
