using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=MultiShopOrderDb; User=sa; Password=123456aA*",
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,               // Bağlantı hatası durumunda en fazla kaç kez deneneceği
                        maxRetryDelay: TimeSpan.FromSeconds(10), // Yeniden denemeler arasında bekleme süresi
                        errorNumbersToAdd: null);       // Belirli hata numaralarını eklemek için kullanılır, genellikle null bırakılır
                });
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}

