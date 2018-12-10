using AutoMapper;
using StockTracker.Repository.AutoMapper;

namespace StockTracker.Repository.Test
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
