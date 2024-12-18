using Microsoft.EntityFrameworkCore;
using Staff.Domain.Models;

namespace Staff.Domain.Context;

public class StaffDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<EmploymentArchiveRecord> EmploymentArchiveRecords { get; set; }
    public DbSet<UnionBenefit> UnionBenefits { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка связи многие-ко-многим между Employee и Department
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Departments)
            .WithMany(d => d.Employees);

        // Настройка связи один-ко-многим между Employee и Workshop
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Workshop)
            .WithMany(w => w.Employees)
            .HasForeignKey(e => e.WorkshopId);

        // Настройка связи один-ко-многим между Employee и Position
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId);

        // Настройка связи один-к-одному между Employee и Address
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Address)
            .WithOne(a => a.Employee)
            .HasForeignKey<Employee>(e => e.AddressId);

        base.OnModelCreating(modelBuilder);
    }
}