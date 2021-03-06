﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TeamChat.Core.Interfaces.Repository;
using TeamChat.Repository;
using TeamChat.Repository.Context;
using Microsoft.EntityFrameworkCore;
using TeamChat.Core.Interfaces.Service;
using TeamChat.Service;
using AutoMapper;
using TeamChat.Core.Model;
using TeamChat.WebUI.Model;

namespace TeamChat.WebUI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TeamChatDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TeamChatConnection")));

            // Add framework services.
            services.AddMvc();

            // Registering Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Registering Services
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
