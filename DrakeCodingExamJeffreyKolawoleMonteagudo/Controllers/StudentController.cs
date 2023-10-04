using DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Repositories;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                return Ok(await _studentService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpGet("StudentRecords/{id}")]
        public async Task<IActionResult> GetStudentRecords(int id)
        {
            try
            {
                return Ok(await _studentService.GetStudentRecordsAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                return Ok(await _studentService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest("Student object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var createdStudent = await _studentService.AddAsync(request);

                return CreatedAtRoute("GetStudent", new { id = createdStudent.Id }, createdStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest("Student object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var result = await _studentService.Update(id, request);

                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var result = await _studentService.Delete(id);

                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
