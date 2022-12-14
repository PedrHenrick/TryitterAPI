using Microsoft.AspNetCore.Mvc;
using TryitterAPI.Models;
using TryitterAPI.Repository;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetStudents());
        }

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

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            _repository.CreateStudent(student);
            return CreatedAtAction("Get", new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            if (student == null || student.StudentId != id) BadRequest();

            var studentInDb = _repository.GetStudentById(id);
            
            if (studentInDb == null) NotFound();

            _repository.UpdateStudent(student, id);
            return Ok();
        }

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
