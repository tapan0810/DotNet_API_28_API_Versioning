using DotNet_API_28.Entities.Models;

namespace DotNet_API_28.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new()
        {
            new Student { Id =1,Name = "John Doe"},
            new Student { Id =2,Name = "Jane Smith"}
        };

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id)!;
        }

        public Student Add(Student student)
        {
            student.Id = students.Max(x => x.Id) + 1;
            students.Add(student);
            return student;
        }

        public Student Update(Student student)
        {
            var existingStudent = students.FirstOrDefault(x => x.Id == student.Id);
            if (existingStudent == null)
            {
                return null!;
            }
            existingStudent.Name = student.Name;
            return existingStudent;
        }

        public bool Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return false;
            }
            students.Remove(student);
            return true;
        }
    }
}
