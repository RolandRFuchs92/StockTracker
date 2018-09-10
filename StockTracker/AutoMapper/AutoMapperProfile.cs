using AutoMapper;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Model.Stock.DTO;

namespace StockTracker.Repository.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
	    public AutoMapperProfile()
	    {
		    CreateMap<IStockItem, StockItem>();
		    CreateMap<IStockLevel, StockLevel>();
		    CreateMap<StockDTO, StockItem>();
	    }
    }
}
