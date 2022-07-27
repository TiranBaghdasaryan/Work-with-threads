using Microsoft.EntityFrameworkCore;
using Work_with_threads.Entities;

namespace Work_with_threads.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name).IsRequired().HasMaxLength(50);
            
            
            // issue  
            // modelBuilder.Entity<Product>().HasCheckConstraint("CK_Price_More_Than_Zero","Price >= 0");
        }
    }
}