using ApiFCamara.Application;
using ApiFCamara.Application.Interfaces;
using ApiFCamara.Domain.Interfaces;
using ApiFCamara.Domain.Interfaces.Services;
using ApiFCamara.Domain.Services;
using ApiFCamara.Infra.Data.Context;
using ApiFCamara.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFCamara.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IProductAppService, ProductAppService>();

            //Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDbContext, ApiFCamaraContext>();

            //Service
            services.AddScoped<IProductService, ProductService>();
            
        }
    }
}
