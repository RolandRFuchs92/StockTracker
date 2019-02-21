using AutoMapper;
using StockTracker.Interface.Models.ClientStock;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.Suppliers;
using StockTracker.Model.Stock;
using StockTracker.Model.Suppliers;

namespace StockTracker.Repository.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
	    public AutoMapperProfile()
	    {
		    CreateMap<IStockCore, StockCore>();
		    CreateMap<IClientStockLevel, IClientStockLevel>();
						CreateMap<ISupplier, Supplier>();
						CreateMap<Supplier, ISupplier>();
	    }
    }
}
