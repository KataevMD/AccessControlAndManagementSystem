using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcmsAPI.Entities;

public partial class AccessСontrolАndManagementInformationSystemContext : DbContext
{
    public AccessСontrolАndManagementInformationSystemContext()
    {
    }

    public AccessСontrolАndManagementInformationSystemContext(DbContextOptions<AccessСontrolАndManagementInformationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessLevel> AccessLevels { get; set; }

    public virtual DbSet<AccessPassagePoint> AccessPassagePoints { get; set; }


    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<DaysTimeZone> DaysTimeZones { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PassagePoint> PassagePoints { get; set; }

    public virtual DbSet<PassagePointDepartment> PassagePointDepartments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<TimeInterval> TimeIntervals { get; set; }

    public virtual DbSet<TimeZone> TimeZones { get; set; }

    public virtual DbSet<TimeZonePassagePoint> TimeZonePassagePoints { get; set; }

    public virtual DbSet<TypeOrder> TypeOrders { get; set; }

    public virtual DbSet<TypePointByAppointment> TypePointByAppointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2DRF9EB\\SQLEXPRESS;Database=AccessСontrolАndManagementInformationSystem;integrated security=True;MultipleActiveResultSets=True;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessLevel>(entity =>
        {
            entity.HasKey(e => e.AccessLevelDepartmentId);

            entity.ToTable("AccessLevel");

            entity.Property(e => e.AccessLevelDepartmentId).HasColumnName("AccessLevelDepartmentID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.PostEmployeeId).HasColumnName("PostEmployeeID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.AccessLevels)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessLevel_Department");

            entity.HasOne(d => d.PostEmployee).WithMany(p => p.AccessLevels)
                .HasForeignKey(d => d.PostEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessLevel_Post");
        });

        modelBuilder.Entity<AccessPassagePoint>(entity =>
        {
            entity.ToTable("AccessPassagePoint");

            entity.Property(e => e.AccessPassagePointId).HasColumnName("AccessPassagePointID");
            entity.Property(e => e.Datetime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PassagePointId).HasColumnName("PassagePointID");

            entity.HasOne(d => d.Employee).WithMany(p => p.AccessPassagePoints)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessPassagePoint_Employee");

            entity.HasOne(d => d.PassagePoint).WithMany(p => p.AccessPassagePoints)
                .HasForeignKey(d => d.PassagePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessPassagePoint_PassagePoint");
        });

        modelBuilder.Entity<Day>(entity =>
        {
            entity.Property(e => e.DayId)
                .ValueGeneratedNever()
                .HasColumnName("DayID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<DaysTimeZone>(entity =>
        {
            entity.HasKey(e => new { e.TimeIntervalId, e.DayId });

            entity.ToTable("DaysTimeZone");

            entity.Property(e => e.TimeIntervalId).HasColumnName("TimeIntervalID");
            entity.Property(e => e.DayId).HasColumnName("DayID");
            entity.Property(e => e.DaysTimeZoneId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DaysTimeZoneID");

            entity.HasOne(d => d.Day).WithMany(p => p.DaysTimeZones)
                .HasForeignKey(d => d.DayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DaysTimeZone_Days");

            entity.HasOne(d => d.TimeInterval).WithMany(p => p.DaysTimeZones)
                .HasForeignKey(d => d.TimeIntervalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DaysTimeZone_TimeInterval");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Departments");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeGuid).HasName("PK_Employees");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeGuid)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeGUID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Post).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Post");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.OrderFile)
                .HasMaxLength(8000)
                .IsFixedLength();
            entity.Property(e => e.OrderNumber).HasMaxLength(50);
            entity.Property(e => e.TypeOrderId).HasColumnName("TypeOrderID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Employee");

            entity.HasOne(d => d.TypeOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TypeOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_TypeOrder");
        });

        modelBuilder.Entity<PassagePoint>(entity =>
        {
            entity.HasKey(e => e.PointId);

            entity.ToTable("PassagePoint");

            entity.Property(e => e.PointId).HasColumnName("PointID");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.TypePointId).HasColumnName("TypePointID");

            entity.HasOne(d => d.TypePoint).WithMany(p => p.PassagePoints)
                .HasForeignKey(d => d.TypePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PassagePoint_TypePointByAppointment");
        });

        modelBuilder.Entity<PassagePointDepartment>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.PointId }).HasName("PK_OfficeDepartment");

            entity.ToTable("PassagePointDepartment");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.PointId).HasColumnName("PointID");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.HasOne(d => d.Department).WithMany(p => p.PassagePointDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfficeDepartment_Department");

            entity.HasOne(d => d.Point).WithMany(p => p.PassagePointDepartments)
                .HasForeignKey(d => d.PointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PassagePointDepartment_PassagePoint");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<TimeInterval>(entity =>
        {
            entity.ToTable("TimeInterval");

            entity.Property(e => e.TimeIntervalId).HasColumnName("TimeIntervalID");
            entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.TimeZone).WithMany(p => p.TimeIntervals)
                .HasForeignKey(d => d.TimeZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeInterval_TimeZone");
        });

        modelBuilder.Entity<TimeZone>(entity =>
        {
            entity.HasKey(e => e.TimeZoneId).HasName("PK_TimeZone");

            entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<TimeZonePassagePoint>(entity =>
        {
            entity.HasKey(e => new { e.AccessLevelId, e.PassagePointId, e.TimeZoneId });

            entity.ToTable("TimeZonePassagePoint");

            entity.Property(e => e.AccessLevelId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AccessLevelID");
            entity.Property(e => e.PassagePointId).HasColumnName("PassagePointID");
            entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");

            entity.HasOne(d => d.AccessLevel).WithMany(p => p.TimeZonePassagePoints)
                .HasForeignKey(d => d.AccessLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeZonePassagePoint_AccessLevel");

            entity.HasOne(d => d.PassagePoint).WithMany(p => p.TimeZonePassagePoints)
                .HasForeignKey(d => d.PassagePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeZonePassagePoint_PassagePoint");

            entity.HasOne(d => d.TimeZone).WithMany(p => p.TimeZonePassagePoints)
                .HasForeignKey(d => d.TimeZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeZonePassagePoint_TimeZone");
        });

        modelBuilder.Entity<TypeOrder>(entity =>
        {
            entity.ToTable("TypeOrder");

            entity.Property(e => e.TypeOrderId).HasColumnName("TypeOrderID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TypePointByAppointment>(entity =>
        {
            entity.HasKey(e => e.TypePointId).HasName("PK_TypeOffice");

            entity.ToTable("TypePointByAppointment");

            entity.Property(e => e.TypePointId).HasColumnName("TypePointID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
