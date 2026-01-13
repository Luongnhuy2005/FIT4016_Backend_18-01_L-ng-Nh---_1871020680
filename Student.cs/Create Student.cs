using SchoolManagementApp.Data;

namespace SchoolManagement
{
    public class StudentService // Đảm bảo có Class bao quanh
    {
        public static void CreateStudent(Student student)
        {
            try
            {
                using var context = new SchoolContext();

                if (!context.Schools.Any(s => s.Id == student.SchoolId))
                    throw new Exception("Selected school does not exist.");

                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}