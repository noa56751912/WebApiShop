using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public ApiShopContext Context { get; private set; }

        public DatabaseFixture()
        {
            string dbName = $"ApiShop_Test_{Guid.NewGuid()}";
            string connectionString=$"Data Source=Noa;Initial Catalog={dbName};Integrated Security=True;Pooling=False;TrustServerCertificate=True";
                // Set up the test database connection and initialize the context
                var options = new DbContextOptionsBuilder<ApiShopContext>()
                
                    .UseSqlServer(connectionString)
                    .Options;
                Context = new ApiShopContext(options);
                Microsoft.Data.SqlClient.SqlConnection.ClearAllPools();
                Context.Database.EnsureDeleted();
                
                Context.Database.EnsureCreated();
            
        }
        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
