using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Model.Stock.DTO;

namespace StockTracker.BusinessLogic.AutoMapper
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
