using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApiApp.Data;
using StudentApiApp.Models;

namespace StudentApiApp.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Route("api/students")]
    //[ApiController]
    //[EnableCors("AllowOrigin")]
    public class StudentsTestController : ControllerBase
    {
        private readonly StudentAppContext _context;

        public StudentsTestController(StudentAppContext context)
        {
            _context = context;
        }

        // GET: api/StudentsTest
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            return _context.Student.ToList();
        }
        //[HttpGet]
        //public IEnumerable<Student> GetAll()
        //{
        //    return _context.Student.Take(4).ToList();
        //}


        // GET: api/StudentsTest/5
        [HttpGet("{id}")]
        public IActionResult GetStudent( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student =_context.Student.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/StudentsTest/5
        [HttpPut("{id}")]
        public IActionResult PutStudent( int id,  Student student)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != student.Id)
            //{
            //    return BadRequest();
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            if (id == student.Id)
            {
                _context.Student.Update(student);
                _context.SaveChanges();
                return Ok(student);
            }
            return BadRequest();

           
        }

        // POST: api/StudentsTest
        [HttpPost]
        public IActionResult PostStudent( Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Student.Add(student);
             _context.SaveChanges();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

     
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
             _context.SaveChanges();

            return Ok(student);
        }

    }
}