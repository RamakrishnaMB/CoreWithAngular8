﻿using AutoMapper;
using CoreBusinessLogic.AutoMapperSettings;
using CoreBusinessLogic.Implementation;
using CoreBusinessLogic.Interface;
using CoreDataLayer;
using CoreDataLayer.Implementation;
using CoreDataLayer.Interface;
using CoreDataLayer.ModelsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Configuration
{
    public static class ConfigStartup
    {
        public static void InitializeStartup(IServiceCollection services, Type startup)
        {
            services.AddDbContext<dbTestContext>(opts => opts.UseSqlServer(ConnectionString.GetConnectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(startup);
            AutoMapperConfig.ConfigureAtApplicationStart();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
