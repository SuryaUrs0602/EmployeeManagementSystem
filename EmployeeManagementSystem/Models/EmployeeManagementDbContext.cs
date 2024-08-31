using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creating one to many relationship between Department and Employee
            modelBuilder.Entity<Department>()
                .HasMany(emp => emp.Employees)
                .WithOne(dept => dept.Department)
                .HasForeignKey(dept => dept.DepartmentID);

            //creating one to many relationship between JobTitle and Employee
            modelBuilder.Entity<JobTitle>()
                .HasMany(emp => emp.Employees)
                .WithOne(job => job.JobTitle)
                .HasForeignKey(emp => emp.JobTitleID);

            //creating one to many relationship between Project and Employee
            modelBuilder.Entity<Project>()
                .HasMany(emp => emp.Employees)
                .WithOne(pro => pro.Project)
                .HasForeignKey(emp => emp.ProjectID);

            //creating one to many realtionship between Project and Task
            modelBuilder.Entity<Project>()
                .HasMany(t => t.Tasks)
                .WithOne(pro => pro.Project)
                .HasForeignKey(t => t.ProjectID);
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Event> Tasks { get; set; }
    }
}
