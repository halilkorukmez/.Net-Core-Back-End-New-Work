using Api.Worker;
using AutoMapper;
using Core.Extentions.Middleware;
using DataAccess.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.AutoMapper.Profiles;
using Services.ServicesExtensions;
using Services.TokenServices;

namespace Api
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

            services.AddControllers();
            #region AutoMapper

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion AutoMapper
            services.LoadMyServices();
            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));
            services.AddDbContextPool<WorkerDataContext>(options => options
                .UseNpgsql(Configuration.GetConnectionString("TestConnectionString"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
