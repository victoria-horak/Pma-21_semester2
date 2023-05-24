using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace andrew.Models;

public partial class KrContext : DbContext
{
    public KrContext()
    {
    }

    public KrContext(DbContextOptions<KrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alldatum> Alldata { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=password;database=kr", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alldatum>(entity =>
        {
            entity.HasKey(e => e.AllDataId).HasName("PRIMARY");

            entity.ToTable("alldata");

            entity.Property(e => e.AllDataId).HasColumnName("AllDataID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.JournalTite).HasMaxLength(50);
            entity.Property(e => e.JournalType).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PRIMARY");

            entity.ToTable("author");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("book");

            entity.HasIndex(e => e.AuthorId, "AuthorID");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("book_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
