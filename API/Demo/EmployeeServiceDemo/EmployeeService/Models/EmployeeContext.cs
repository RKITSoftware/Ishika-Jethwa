
using System.Data.Entity;

namespace EmployeeService.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeDbContext")
        {
        }
        public DbSet<EmployeeTable> EmployeeTables { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTable>().HasKey(e => e.p01f01);
            modelBuilder.Entity<EmployeeTable>().Property(e => e.p01f02).HasColumnName("p01f02");

            // other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}