using Microsoft.EntityFrameworkCore;

public class StudentService
{
    // 1. Create Student
    public static void CreateStudent(Student student)
    {
        try
        {
            using var context = new SchoolContext();

            // Check if School exists
            if (!context.Schools.Any(s => s.Id == student.SchoolId))
            {
                Console.WriteLine("Error: Selected school does not exist.");
                return;
            }

            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Success: Student created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during creation: {ex.InnerException?.Message ?? ex.Message}");
        }
    }

    // 2. Read Students with Pagination (10 per page)
    public static void ListStudents(int page = 1)
    {
        using var context = new SchoolContext();
        int pageSize = 10;

        var students = context.Students
            .Include(s => s.School)
            .OrderBy(s => s.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        Console.WriteLine($"--- Student List (Page {page}) ---");
        Console.WriteLine("{0,-20} | {1,-10} | {2,-20} | {3,-12} | {4,-15}", "Full Name", "ID", "Email", "Phone", "School");

        foreach (var s in students)
        {
            Console.WriteLine("{0,-20} | {1,-10} | {2,-20} | {3,-12} | {4,-15}",
                s.FullName, s.StudentId, s.Email, s.Phone ?? "N/A", s.School?.Name);
        }
    }

    // 3. Update Student
    public static void UpdateStudent(int id, string newName, string newEmail)
    {
        try
        {
            using var context = new SchoolContext();
            var student = context.Students.Find(id);
            if (student == null) throw new Exception("Student not found.");

            student.FullName = newName;
            student.Email = newEmail;
            student.UpdatedAt = DateTime.Now;

            context.SaveChanges();
            Console.WriteLine("Success: Student updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 4. Delete Student
    public static void DeleteStudent(int id)
    {
        try
        {
            using var context = new SchoolContext();
            var student = context.Students.Find(id);
            if (student == null) return;

            Console.Write($"Are you sure you want to delete {student.FullName}? (Y/N): ");
            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Success: Student deleted.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}