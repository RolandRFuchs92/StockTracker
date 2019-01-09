using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Tests.Utils.Context;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
    [TestClass]
    public class StockTypeRepoTest
    {
        private IStockTrackerContext _db;

        [TestMethod]
        public void StockTypes()
        {

            var db = new TestDbFactory().Db();
            var addSeed = new AddSeed(db, "Clients");
            var wee = "";
        }
    }
}
