using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class KitchenerBadgeSystemContext : IdentityDbContext

{
    public KitchenerBadgeSystemContext()
    {
    }

    public KitchenerBadgeSystemContext(DbContextOptions<KitchenerBadgeSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Guard> Guards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=tcp:empsystem.database.windows.net,1433;Initial Catalog=EmployeeSystem;User ID=pratt;Password=Hanu@123;Encrypt=False;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpCode);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpCode).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasColumnName("PhotoURL");
        });

        modelBuilder.Entity<Guard>(entity =>
        {
            entity.ToTable("Guard");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.EmpCodeNavigation).WithMany(p => p.Guards)
                .HasForeignKey(d => d.EmpCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Guard_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
