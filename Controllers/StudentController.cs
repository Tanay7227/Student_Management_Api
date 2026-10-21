using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_1.Models;

namespace Practice_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentdatabaseContext dbdata;

        public StudentController(StudentdatabaseContext dbdata)
        {
            this.dbdata = dbdata;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDb>>> GetStudents()
        {
            var data = await dbdata.StudentDbs.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<StudentDb>>> GetStudentsbyid(int id)
        {
            var student_Id = await dbdata.StudentDbs.FindAsync(id);
            if(student_Id == null)
            {
                return NotFound();
            }
            return Ok(student_Id);
        }

        [HttpPost]
        public async Task<ActionResult<List<StudentDb>>> Create(StudentDb std)
        { 
            await dbdata.StudentDbs.AddAsync(std);
            await dbdata.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut]
        public async Task<ActionResult<List<StudentDb>>> Update(int id,StudentDb std)
        {
            if(id != std.Id)
            {
                return BadRequest();
            }
            dbdata.Entry(std).State = EntityState.Modified;
            await dbdata.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete]
        public async Task<ActionResult<List<StudentDb>>> Delete(int id)
        {
            var std = await dbdata.StudentDbs.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }
            dbdata.StudentDbs.Remove(std);
            await dbdata.SaveChangesAsync();
            return Ok();
        }
    }
}
