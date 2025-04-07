using MAUISql.Data;
using MAUISql.Models;
using SQLite;
using System.IO;

namespace MAUISql.Tests
{
    public class TestDatabaseContext : DatabaseContext
    {
        public TestDatabaseContext() : base(":memory:")
        {
            InitAsync().Wait();
        }

        private async Task InitAsync()
        {
            await CreateTableIfNotExists<Product>();
        }
    }
}
