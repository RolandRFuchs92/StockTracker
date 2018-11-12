﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.BusinessLogic.Inteface.Client;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

	        services.AddOptions();
	        services.AddTransient<IStockTrackerContext, StockTrackerContext>();
	        services.AddTransient<IClientRepo, ClientRepo>();
			services.AddTransient<IClientLogic, ClientLogic>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
