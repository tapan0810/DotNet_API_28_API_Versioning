using DotNet_API_28.Entities.DTOs.V1;
using DotNet_API_28.Entities.Models;
using DotNet_API_28.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_API_28.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAllStudents()
                .Select(s => new StudentV1Dto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with Id {id} not found.");
            }

            var dto = new StudentV1Dto
            {
                Id = student.Id,
                Name = student.Name
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(StudentV1Dto dto)
        {
            var student = new Student
            {
                Name = dto.Name
            };

            var addedStudent = _studentService.Add(student);

            var result = new StudentV1Dto
            {
                Id = addedStudent.Id,
                Name = addedStudent.Name
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentV1Dto dto)
        {
            var student = new Student
            {
                Id = id,
                Name = dto.Name
            };

            var updatedStudent = _studentService.Update(student);

            if (updatedStudent == null)
            {
                return NotFound($"Student with Id {id} not found.");
            }

            var result = new StudentV1Dto
            {
                Id = updatedStudent.Id,
                Name = updatedStudent.Name
            };

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _studentService.Delete(id);

            if (!deleted)
            {
                return NotFound($"Student with Id {id} not found.");
            }

            return Ok($"Student with Id {id} deleted successfully.");
        }
    }
}