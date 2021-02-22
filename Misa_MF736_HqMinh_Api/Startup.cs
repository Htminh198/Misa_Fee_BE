using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Misa_MF736_HqMinh_Common.Common;
using Misa_MF736_HqMinh_DataLayer.FeeDataLayer;
using Misa_MF736_HqMinh_DataLayer.FeeGroupDatalayer;
using Misa_MF736_HqMinh_Service.BaseService;
using Misa_MF736_HqMinh_Service.FeeGroupService;
using Misa_MF736_HqMinh_Service.FeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*")
                                                    .AllowAnyHeader()
                                                  .AllowAnyMethod();
                                  });
            });
           
            services.AddControllers();
            services.AddTransient<IFeeService, FeeService>();
            services.AddTransient<IFeeDataLayer, FeeDataLayer>();
            services.AddTransient<IFeeGroupService, FeeGroupService>();
            services.AddTransient<IFeeGroupDatalayer, FeeGroupDatalayer>();
            //cấu hình DI
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Misa_MF736_HqMinh_Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Misa_MF736_HqMinh_Api v1"));
            };
            //app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseCors(MyAllowSpecificOrigins);
            //Xử lý Exception chung 
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errorMsg = new ErrorMsg();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg.Add(Misa_MF736_HqMinh_Common.Properties.Resources.Exception);
                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                await context.Response.WriteAsJsonAsync(errorMsg);
            }));

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
