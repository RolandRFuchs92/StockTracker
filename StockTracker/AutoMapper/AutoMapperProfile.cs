using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.BusinessLogic.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
	    public AutoMapperProfile()
	    {
		    CreateMap<IStockItem, StockItem>();
	    }
    }
}
