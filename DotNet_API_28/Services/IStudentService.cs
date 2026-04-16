using DotNet_API_28.Entities.Models;

namespace DotNet_API_28.Services
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public Student GetById(int id);
        public Student Add(Student student);
        public Student Update(Student student);
        public bool Delete(int id);


    }
}
