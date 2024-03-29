﻿using System;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBookApi.Configuration
{
    public static class DepencyInjector
    {
        private static IConfiguration _configuration;

        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;

            services.AddServicesDependencies();
            services.AddRepositoriesDependencies();
            services.AddDatabaseConfiguration();
        }

        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactService>();
        }

        public static void AddRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
        }

        public static void AddDatabaseConfiguration(this IServiceCollection services)
        {
            //var serverInfo = _configuration.GetSection("db:serverInfo").Value;
            //var credential = Environment.GetEnvironmentVariable("PHONEBOOKDBCREDENTIAL");
            //var connectionString = $"{serverInfo}{credential}";

            var connectionString =
                "Server=tcp:phonebookserver.database.windows.net,1433;Initial Catalog=PhoneBook_Florian;Persist Security Info=False;User ID=PhonebookAdmin;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<PhoneBookDbContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(connectionString));
        }
    }
}