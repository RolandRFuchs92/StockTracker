using AutoMapper;
using StockTracker.Interface.Models.ClientStock;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Repository.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
	    public AutoMapperProfile()
	    {
		    CreateMap<IStockCore, StockCore>();
		    CreateMap<IClientStockLevel, IClientStockLevel>();
	    }
    }
}
