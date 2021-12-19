using Microsoft.EntityFrameworkCore;
using NextensTaxTool.Entities;

namespace NextensTaxTool.Context
{
    public class NextensDbContext : DbContext
    {
        public NextensDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClientFinancialData> ClientFinancialData { get; set; }
    }
}
