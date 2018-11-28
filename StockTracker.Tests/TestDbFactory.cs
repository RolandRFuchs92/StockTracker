using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Seed;

namespace StockTracker.Repository.Test
{
    public class TestDbFactory : IDisposable
    {
	    public StockTrackerContext Db { get; private set; }
        private SqliteConnection _connection;
        private bool IsActive;

        private DbContextOptions<StockTrackerContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<StockTrackerContext>()
                .UseSqlite(_connection).Options;
        }

        public StockTrackerContext CreateContext()
        {

            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new StockTrackerContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new StockTrackerContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
