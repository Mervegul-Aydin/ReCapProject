using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // bu class : db tabloları ile proje classlarını bağlamak için oluşturduğumuz class
    // context : db tabloları ile proje classlarını bağlamak
    public class ReCapDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // sql servera bağlanma
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyReCapProject;Trusted_Connection=true"); // peki hangi veri tabanına bağlanıcam onun cevabı
        }

        public DbSet<Car> Cars { get; set; } // benim Car nesnemi db'de Cars ile bağla bunu dbset ile yapıyoruz.
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
