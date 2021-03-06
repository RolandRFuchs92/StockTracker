﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.StockSupplier
{
    public interface IStockStupplierDetail
    {
		int StockSupplierDetailId { get; set; }
		int SupplierId { get; set; }
		int MemberId { get; set; }
		decimal Price { get; set; }
		int UnitTypeId { get; set; }
		int Unit { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
