﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Persons;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Interface;

namespace StockTracker.Tests.Utils.Context
{
    public class AddSeed
    {
        private IStockTrackerContext _db;
        private Type dbsetType { get; set; }

        public AddSeed(IStockTrackerContext db, string dbSetName)
        {
            _db = db;
            AddSeedList(dbSetName);
        }

        public void NewSeed(string dbSetName)
        {
            AddSeedList(dbSetName);
        }

        private void AddSeedList(string dbSetName)
        {
            dbsetType = GetDbSetType(dbSetName);
            var assembly = Assembly.Load("StockTracker.Seed");

            var seedType = (from seed in assembly.GetTypes()
                             where seed.GetInterfaces().Length > 0
                                   && seed.GetInterfaces()[0].IsConstructedGenericType
                                   && seed.GetInterfaces()[0].GenericTypeArguments[0] == dbsetType
                            select seed).FirstOrDefault();

            var instanceObject = Activator.CreateInstance(seedType);
            instanceObject.GetType().GetMethod(nameof(GenericSeed<Person>.SeedContext)).Invoke(instanceObject, new object[]{ _db });
        }

        private Type GetDbSetType(string dbsetName)
        {
            var obj = _db.GetType().GetProperty(dbsetName).PropertyType.GenericTypeArguments;

            return obj[0];
        }
    }
}
