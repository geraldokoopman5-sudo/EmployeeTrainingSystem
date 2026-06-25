using EmployeeTrainingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrainingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EmployeeCourse> EmployeeCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

            modelBuilder.Entity<EmployeeCourse>()
            .HasOne(ec => ec.Employee)
            .WithMany(e => e.EmployeeCourses)
            .HasForeignKey(ec => ec.EmployeeId);

            modelBuilder.Entity<EmployeeCourse>()
            .HasOne(ec => ec.Course)
            .WithMany(c => c.EmployeeCourses)
            .HasForeignKey(ec => ec.CourseId);

        }
            
    }
}
