using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class NorthwindContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }//dbset ile tablodan cekiyoruz.
        //veritabanına bir bağlantı açar, verileri veritabanına getirmek veya veritabanına göndermek için bir DataSet olusturuyoruz.
        //Db database--veri tabanı
        public DbSet<Category> Categories { get; set; }
        public DbSet<Costumer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
