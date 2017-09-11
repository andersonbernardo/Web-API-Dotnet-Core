using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using AutoMapper;
using ApiFCamara.Infra.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ApiFCamara.Services.WebApi.Configuration;
using ApiFCamara.Infra.Data;
using System;

namespace ApiFCamara.Services.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);           

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
       
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           

            services.AddAutoMapper();
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {   
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {                    
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtTokenConfiguration:Key"])),
                    ValidIssuer = Configuration["JwtTokenConfiguration:Issuer"],
                    ValidAudience = Configuration["JwtTokenConfiguration:Audience"],
                    ValidateLifetime = true,
                    RequireExpirationTime = true                   
                    
                };
            });

            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().RequireClaim("management").Build();
            });

            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "API FCamara",
            //        Description = "API FCamara surface",
            //        Contact = new Contact { Name = "Anderson Bernardo", Email = "anderson.bernardo1@gmail.com", Url = "" }

            //    });
            //});

            services.Configure<JwtTokenConfiguration>(options => Configuration.GetSection("JwtTokenConfiguration").Bind(options));

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            //app.UseSwagger();

            //app.UseSwaggerUI(s =>
            //{
            //    s.SwaggerEndpoint("/swagger/v1/swagger.json", "FCamara API v1");
            //});


            DbInitializer.Initialize();
        }

        private static void RegisterServices(IServiceCollection services)
        {            
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
