using EmployeeManagment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data
{
    public class EmployeeDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
   
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many: One Department can have many Employees
            modelBuilder.Entity<Department>()
                        .HasMany(d => d.Employees)
                        .WithOne(e => e.Department)
                        .HasForeignKey(e => e.DepartmentId)
                        .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many: One Project can have many Employees assigned through the EmployeeProject model
            modelBuilder.Entity<Project>()
                        .HasMany(p => p.EmployeeProjects)
                        .WithOne(ep => ep.Project)
                        .HasForeignKey(ep => ep.ProjectId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many: Employees can work on multiple Projects, and Projects can have multiple Employees through the EmployeeProject model
            modelBuilder.Entity<EmployeeProject>()
                        .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                        .HasOne(ep => ep.Employee)
                        .WithMany(e => e.EmployeeProjects)
                        .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                        .HasOne(ep => ep.Project)
                        .WithMany(p => p.EmployeeProjects)
                        .HasForeignKey(ep => ep.ProjectId);

            // One-to-Many: One Employee can have many Attendance records
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Attendances)
                        .WithOne(a => a.Employee)
                        .HasForeignKey(a => a.EmployeeId)
                        .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
