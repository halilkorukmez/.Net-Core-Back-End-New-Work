using DataAccess.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.DataContext
{
    public class ShopDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-147B76S;Database=KursDeneme;Trusted_Connection=True");
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
         
        }



        
        


    }
}
