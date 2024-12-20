using Microsoft.EntityFrameworkCore;
using Staff.Domain.Models;

namespace Staff.Domain.Context;

/// <summary>
/// Представляет контекст базы данных для хранения сотрудников предприятия.
/// </summary>
public class StaffDbContext : DbContext
{
    public StaffDbContext(DbContextOptions<StaffDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Сотрудники предприятия.
    /// </summary>
    public DbSet<Employee> Employees => Set<Employee>();
    /// <summary>
    /// Отделы предприятия.
    /// </summary>
    public DbSet<Department> Departments => Set<Department>();
    /// <summary>
    /// Должности на предприятии.
    /// </summary>
    public DbSet<Position> Positions => Set<Position>();
    /// <summary>
    /// Цеха предприятия.
    /// </summary>
    public DbSet<Workshop> Workshops => Set<Workshop>();
    /// <summary>
    /// Архивные записи о трудоустройстве сотрудников.
    /// </summary>
    public DbSet<EmploymentArchiveRecord> EmploymentArchiveRecords => Set<EmploymentArchiveRecord>();
    /// <summary>
    /// Льготы профсоюза.
    /// </summary>
    public DbSet<UnionBenefit> UnionBenefits => Set<UnionBenefit>();
    /// <summary>
    /// Адреса сотрудников.
    /// </summary>
    public DbSet<Address> Addresses => Set<Address>();

    /// <summary>
    /// Настраивает модель данных.
    /// </summary>
    /// <param name="modelBuilder">Построитель модели данных.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        // Настройка связи многие-ко-многим между Employee и Department
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Departments)
            .WithMany(d => d.Employees)
            .UsingEntity(j => j.ToTable("EmployeeDepartments"));

        // Настройка связи один-ко-многим между Employee и Workshop
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Workshop)
            .WithMany(w => w.Employees)
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        // Настройка связи один-ко-многим между Employee и Position
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Настройка связи один-к-одному между Employee и Address
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Address)
            .WithOne(a => a.Employee)
            .HasForeignKey<Employee>(e => e.AddressId)
            .OnDelete(DeleteBehavior.Cascade);

        // Настройка первичных ключей
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.RegistrationNumber);

        modelBuilder.Entity<Department>()
            .HasKey(d => d.DepartmentId);

        modelBuilder.Entity<Position>()
            .HasKey(p => p.PositionId);

        modelBuilder.Entity<Workshop>()
            .HasKey(w => w.WorkshopId);

        modelBuilder.Entity<EmploymentArchiveRecord>()
            .HasKey(r => r.RecordId);

        modelBuilder.Entity<UnionBenefit>()
            .HasKey(u => u.UnionBenefitId);

        modelBuilder.Entity<Address>()
            .HasKey(a => a.AddressId);

        // Настройка индексов
        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.DateOfHire);

        modelBuilder.Entity<Department>()
            .HasIndex(d => d.Name);

        modelBuilder.Entity<Position>()
            .HasIndex(p => p.Title);

        base.OnModelCreating(modelBuilder);
    }
}