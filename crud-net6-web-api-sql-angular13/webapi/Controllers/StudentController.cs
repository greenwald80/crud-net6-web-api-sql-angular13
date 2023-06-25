using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Data.Entities;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly CrudDbContext _crudDbContext;
        public StudentController(CrudDbContext crudDbContext)
        {
            _crudDbContext = crudDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _crudDbContext.Student.ToListAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student payload)
        {
            _crudDbContext.Student.Add(payload);
            await _crudDbContext.SaveChangesAsync();
            return Ok(payload);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Student payload)
        {
            _crudDbContext.Student.Update(payload);
            await _crudDbContext.SaveChangesAsync();
            return Ok(payload);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var studentToDelete = await _crudDbContext.Student.FindAsync(id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            _crudDbContext.Student.Remove(studentToDelete);
            await _crudDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
