using Microsoft.EntityFrameworkCore;
using VaccineEmployeeSystem.Core.Domain.Models.Employees;

namespace VaccineEmployeeSystem.Core.Infra.Data.Context
{
    public class VaccineEmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeVaccination> EmployeeVaccinations { get; set; }

        public VaccineEmployeeDbContext(DbContextOptions<VaccineEmployeeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(s => s.Vaccination)
                .WithOne(ad => ad.Employee)
                .HasForeignKey<EmployeeVaccination>(ad => ad.EmployeeId);
        }
    }
}
