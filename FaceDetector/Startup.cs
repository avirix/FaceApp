using AutoMapper;

using FaceDetector.Abstractions.Repositories;
using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Database;
using FaceDetector.Domain.Database.Repositories;
using FaceDetector.Mappings;
using FaceDetector.Middlewares;
using FaceDetector.Services.Abstract;
using FaceDetector.Services.Concrete;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            string connection = Configuration.GetConnectionString("SQLAzureConnectionString");
            if (connection.Contains("#"))
                connection = Configuration.GetConnectionString("SQLLocalConnectionString");

            // initialize db context
            services.AddDbContext<FaceAppDbContext>(options => options.UseSqlServer(connection, action => action.MigrationsAssembly("FaceDetector.Domain")));

            // add services to DI
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddTransient(typeof(IBaseModelService<,>), typeof(BaseModelService<,>));
            services.AddTransient<IFaceService, FaceService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFolderService, FolderService>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

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
            }

            // apply automigrations
            // NOTE: context disposed in block below
            // (not available in another part of method)
            using (context)
            {
                context.Database.Migrate();
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
