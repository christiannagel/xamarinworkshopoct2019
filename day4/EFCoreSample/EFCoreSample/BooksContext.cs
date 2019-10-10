using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample2;trusted_connection=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(20);

            modelBuilder.Entity<Book>().Property(b => b.Isbn).HasMaxLength(20);
        }

        public DbSet<Book> Books { get; set; } = default!;
    }
}
