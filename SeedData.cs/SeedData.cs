using Bogus;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Data
{
    public static class DataSeeder
    {
        public static void Seed(SchoolContext context)
        {
            if (context.Schools.Any()) return;

            var schoolFaker = new Faker<School>()
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Principal, f => f.Name.FullName())
                .RuleFor(s => s.Address, f => f.Address.FullAddress());

            var schools = schoolFaker.Generate(10);
            context.Schools.AddRange(schools);
            context.SaveChanges();

            var studentFaker = new Faker<Student>()
                .RuleFor(s => s.FullName, f => f.Name.FullName())
                .RuleFor(s => s.StudentCode, f => f.Random.AlphaNumeric(8))
                .RuleFor(s => s.Email, f => f.Internet.Email())
                .RuleFor(s => s.Phone, f => f.Random.Replace("0#########"))
                .RuleFor(s => s.SchoolId, f => f.PickRandom(schools).Id);

            var students = studentFaker.Generate(20);
            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}
