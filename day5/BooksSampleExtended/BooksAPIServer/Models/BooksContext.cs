using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksAPIServer
{
    public partial class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.Isbn).HasMaxLength(20);

                entity.Property(e => e.Publisher).HasMaxLength(20);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
