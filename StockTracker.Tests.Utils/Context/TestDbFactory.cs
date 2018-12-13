using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StockTracker.Context;

namespace StockTracker.Tests.Utils.Context
{
    public class TestDbFactory : IDisposable
    {
        private SqliteConnection _connection;
        private bool IsActive;

        private DbContextOptions<StockTrackerContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<StockTrackerContext>()
                .UseSqlite(_connection).Options;
        }

        public StockTrackerContext Db()
        {
            return CreateContext();
        }

        private StockTrackerContext CreateContext()
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
