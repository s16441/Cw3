using System;
using Cwiczenie3.DAL;
using Microsoft.AspNetCore.Mvc;
using Cwiczenie3.Models;
namespace Cwiczenie3.Controllers

  {
    [ApiController]
    [Route("api/students")]

    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 1 || id == 2)
            {
                return Ok("Usuwanie dokończone");
            }

            return NotFound("Nie znaleziono studenta");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            if (id == 1 || id == 2)
            {
                return Ok("Aktualizacja dokończona");
            }

            return NotFound("Nie znaleziono studenta");
        }
        [HttpPost]
        public IActionResult CreateStudent(Models.Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

    }
}