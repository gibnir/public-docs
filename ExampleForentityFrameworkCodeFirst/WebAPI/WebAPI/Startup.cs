using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using WebAPI.Models;

namespace WebAPI
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
            // by defult c# use serilizer to remove capital letters (_camalcase by difault).
            // to to disable need to use addjsonOptions (line 33).
            services.AddMvc().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1).
                AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null) {
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                    }
                });

            services.AddDbContext<PaymentDetailsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            // add Cors
            /*
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder
                    .WithOrigins("http://localhost:4200", "Access-Control-Allow-Origin", "Access-Control-Allow-Credentials")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build());
            });
            */
            /*
            services.AddCors(options => {
                options.AddDefaultPolicy(
                    policy => {
                        policy
                        // .WithOrigins("http://localhost:4200")
                        // .AllowAnyOrigin()
                        .WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*")
                        .WithExposedHeaders("*");
                        // .AllowAnyHeader()
                        // .AllowAnyMethod()
                        // .AllowCredentials();
                    });
            });
            */
            services.AddCors(options => options
            .AddDefaultPolicy(policy => {
                policy
                .WithOrigins("http://localhost:4200", "Access-Control-Allow-Origin", "Access-Control-Allow-Credentials")
                // .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                .SetIsOriginAllowed(origin => true) // allow any origin
                // .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod().Build();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            // Configure Cors for use.
            // app.UseCors();
            // app.UseCors("CorsPolicy");
            /*
            app.UseCors(options =>
            options
            .WithOrigins("*")
            .WithHeaders("*")
            .WithMethods("*").Build());
            */
            
            app.UseCors();
            
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
