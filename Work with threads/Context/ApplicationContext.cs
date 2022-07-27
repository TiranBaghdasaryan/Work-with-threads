using System;
using Microsoft.EntityFrameworkCore;
using Work_with_threads.Entities;

namespace Work_with_threads.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.Id).ValueGeneratedOnAdd()
                    .IsRequired().HasMaxLength(50);
            });

            #region SeedData

            User[] users = new User[1000];

            for (int i = 0; i < users.Length; i++)
            {
                users[i] = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = Common.Random.GetRandomName(),
                    Number = Common.Random.GetRandomNumber(),
                    Date = DateTime.Now.Date
                };
            }

            modelBuilder.Entity<User>().HasData(users);

            #endregion
        }
    }
}