using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Thay đổi chuỗi kết nối phù hợp với máy của bạn
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolManagement;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Schools (10 records)
        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<School>().HasData(new School
            {
                Id = i,
                Name = $"School {i}",
                Principal = $"Principal {i}",
                Address = $"Address {i}"
            });
        }

        // Seed Students (20 records)
        for (int i = 1; i <= 20; i++)
        {
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = i,
                SchoolId = (i % 10) + 1,
                FullName = $"Student Name {i}",
                StudentId = $"STD{1000 + i}",
                Email = $"student{i}@example.com",
                Phone = "0123456789"
            });
        }
    }
}