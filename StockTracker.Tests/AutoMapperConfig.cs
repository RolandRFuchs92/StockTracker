using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockTracker.BusinessLogic.AutoMapper;

namespace StockTracker.Test
{
    public static class AutoMapperConfig
    {
	    public static Mapper Get()
	    {
		    var autoMapperProfile = new AutoMapperProfile();
		    var configuration = new MapperConfiguration(cfg => cfg.AddProfile(autoMapperProfile));
			return new Mapper(configuration);
		}

	}
}
