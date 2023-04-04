using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Entities;

public partial class MydatabaseContext : DbContext
{
    public MydatabaseContext()
    {
    }

    public MydatabaseContext(DbContextOptions<MydatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_table");

            entity.Property(e => e.Firstname)
                .HasMaxLength(45)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(45)
                .HasColumnName("lastname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
