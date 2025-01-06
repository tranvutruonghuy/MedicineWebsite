using MedicineProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
    }
}
