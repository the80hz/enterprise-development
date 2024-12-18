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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}