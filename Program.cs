using SchoolManagementApp.Services;

while (true)
{
    Console.WriteLine("\n====== STUDENT MANAGEMENT ======");
    Console.WriteLine("1. Create Student");
    Console.WriteLine("2. List Students");
    Console.WriteLine("3. Update Student");
    Console.WriteLine("4. Delete Student");
    Console.WriteLine("0. Exit");

    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            StudentService.CreateStudent();
            break;

        case "2":
            Console.Write("Enter page number: ");
            int page = int.Parse(Console.ReadLine());
            StudentService.ListStudents(page);
            break;

        case "3":
            StudentService.UpdateStudent();
            break;

        case "4":
            StudentService.DeleteStudent();
            break;

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
