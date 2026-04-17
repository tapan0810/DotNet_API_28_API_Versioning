using DotNet_API_28.Entities.DTOs.V2;
using DotNet_API_28.Entities.Models;
using DotNet_API_28.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_API_28.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v2{version:apiVersion}/students")]
    public class StudentV2Controller : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentV2Controller(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAllStudents()
                .Select(s =>
                {
                    var nameParts = SplitName(s.Name);

                    return new StudentV2Dto
                    {
                        Id = s.Id,
                        FirstName = nameParts.firstName,
                        LastName = nameParts.lastName
                    };
                })
                .ToList();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound($"Student with Id {id} not found.");
            }

            var nameParts = SplitName(student.Name);

            var dto = new StudentV2Dto
            {
                Id = student.Id,
                FirstName = nameParts.firstName,
                LastName = nameParts.lastName
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(StudentV2Dto dto)
        {
            var student = new Student
            {
                Name = CombineName(dto.FirstName, dto.LastName)
            };

            var addedStudent = _studentService.Add(student);
            var nameParts = SplitName(addedStudent.Name);

            var result = new StudentV2Dto
            {
                Id = addedStudent.Id,
                FirstName = nameParts.firstName,
                LastName = nameParts.lastName
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentV2Dto dto)
        {
            var student = new Student
            {
                Id = id,
                Name = CombineName(dto.FirstName, dto.LastName)
            };

            var updatedStudent = _studentService.Update(student);

            if (updatedStudent == null)
            {
                return NotFound($"Student with Id {id} not found.");
            }

            var nameParts = SplitName(updatedStudent.Name);

            var result = new StudentV2Dto
            {
                Id = updatedStudent.Id,
                FirstName = nameParts.firstName,
                LastName = nameParts.lastName
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

        private static (string firstName, string lastName) SplitName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return (string.Empty, string.Empty);
            }

            var parts = fullName.Trim().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            var firstName = parts.Length > 0 ? parts[0] : string.Empty;
            var lastName = parts.Length > 1 ? parts[1] : string.Empty;

            return (firstName, lastName);
        }

        private static string CombineName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}".Trim();
        }
    }
}