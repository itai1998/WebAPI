using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCoursesRepository studentCoursesRepository;

        public StudentCoursesController(IStudentCoursesRepository studentCoursesRepository)
        {
            this.studentCoursesRepository = studentCoursesRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentCourses>> GetStudentCoursesData()
        {
            try
            {
                var studentCourses = studentCoursesRepository.GetAll();
                return Ok(studentCourses);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while retrieving data.");
            }
        }

        [HttpGet("{emplid}/{courseId}")]
        public ActionResult<StudentCourses> GetStudentCourses(string emplid, string courseId)
        {
            var studentCourses = studentCoursesRepository.Get(emplid, courseId);

            if (studentCourses == null)
                return NotFound();

            return Ok(studentCourses);
        }

        [HttpDelete("{emplid}/{courseId}")]
        public ActionResult DeleteStudentCourses(string emplid, string courseId)
        {
            var studentCourses = studentCoursesRepository.Get(emplid, courseId);

            if (studentCourses == null)
                return NotFound();

            studentCoursesRepository.Delete(emplid, courseId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<StudentCourses> AddStudentCourses(StudentCourses studentCourses)
        {
            if (studentCourses == null)
            {
                return BadRequest("Invalid student course data");
            }

            try
            {
                studentCourses = studentCoursesRepository.Add(studentCourses);
                return Ok(studentCourses);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while adding data.");
            }
        }

        [HttpPut("{emplid}/{courseId}")]
        public ActionResult<StudentCourses> UpdateStudentCourses(string emplid, string courseId, StudentCourses updatedStudentCourses)
        {
            var existingStudentCourses = studentCoursesRepository.Get(emplid, courseId);

            if (existingStudentCourses == null)
                return NotFound();

            existingStudentCourses.GRADE = updatedStudentCourses.GRADE;
            existingStudentCourses.SCORE = updatedStudentCourses.SCORE;

            try
            {
                studentCoursesRepository.Update(existingStudentCourses);
                return Ok(existingStudentCourses);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while updating data.");
            }
        }
    }
}
