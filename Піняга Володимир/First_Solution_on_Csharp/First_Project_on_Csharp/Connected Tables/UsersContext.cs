using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC.Entities;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jobplace> Jobplaces { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=df42k9@wqbnYU808;database=users");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jobplace>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("jobplace");

            entity.Property(e => e.Company).HasMaxLength(45);
            entity.Property(e => e.Location).HasMaxLength(45);
            entity.Property(e => e.Position).HasMaxLength(45);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.JobId, "JobId");

            entity.HasIndex(e => e.UserInfoId, "UserInfoId");

            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Surname).HasMaxLength(45);

            entity.HasOne(d => d.Job).WithMany(p => p.Users)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("user_ibfk_1");

            entity.HasOne(d => d.UserInfo).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserInfoId)
                .HasConstraintName("user_ibfk_2");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("userinfo");

            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.someInfo)
                .HasMaxLength(45)
                .HasColumnName("someInfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
