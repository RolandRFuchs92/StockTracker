﻿using System;
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
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Adapter.Logger;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.API
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
						services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

						var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StockTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
						services.AddDbContext<StockTrackerContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("StockTracker.API")));

						services.AddOptions();
						services.AddTransient<IStockTrackerContext, StockTrackerContext>();
						services.AddTransient<IClientRepo, ClientRepo>();
						services.AddTransient<IClientLogic, ClientLogic>();
						services.AddTransient(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

						services.AddCors();

						services.AddLogging();
				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
				{
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
						}
						loggerFactory.AddFile("c:/temp/MOOOOOO-{Date}.txt");

						app.UseCors(builder => builder
								.WithOrigins("http://localhost:8080")
								.AllowAnyHeader());

						app.UseMvc();
				}
		}
}
