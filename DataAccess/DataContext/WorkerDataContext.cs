using DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using Entities.PageUrls;
using Entities.Users;

namespace DataAccess.DataContext
{
    public class WorkerDataContext : DbContext
    {
        public WorkerDataContext(DbContextOptions<WorkerDataContext> options ) : base(options)
        {
            
        }

        public DbSet<PageUrl> PageUrls { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql(@"ConnectionString")
                    .EnableSensitiveDataLogging(true)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PageUrlsMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());

        }



        
        


    }
}
