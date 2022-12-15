using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryitterWebAPI.Interfaces;
using TryitterWebAPI.Models;
using TryitterWebAPI.Repository;

namespace TryitterWebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _repository;

        public StudentController(StudentRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetStudents());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Authorize]
        [HttpGet("posts")]
        public async Task<IActionResult> GetStudentsWithPosts()
        {
            var students = await _repository.GetStudentsWithPosts();
            if (!students.Any() == true)
            {
                return NotFound("Students not fount");
            }

            return Ok(students);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            if (student == null || student.StudentId != id) BadRequest();

            var studentInDb = _repository.GetStudentById(id);
            
            if (studentInDb == null) NotFound();

            _repository.UpdateStudent(student, id);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var studentInDb = _repository.GetStudentById(id);
            if (studentInDb == null) NotFound();
     
            _repository.DeleteStudent(id);
            return NoContent();
        }
    }
}
