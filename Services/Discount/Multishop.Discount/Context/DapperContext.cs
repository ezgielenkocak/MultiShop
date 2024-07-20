using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Multishop.Discount.Entities;
using System.Data;

namespace Multishop.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _confiuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration confiuration)
        {
            _confiuration = confiuration;
            _connectionString = _confiuration.GetConnectionString("DefaultConnection");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-V44F1G3; initial Catalog=MultishopDiscountDb; integrated Security=true");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
