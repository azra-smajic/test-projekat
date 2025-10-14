using Microsoft.AspNetCore.Mvc;
using WebApplication2.Db;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<StudentGetByIdResponse> GetById(int id)
        {
            var s = DatabaseContext.Studenti.Find(x => x.Id == id);
            var response = new StudentGetByIdResponse(s.Id, s.Ime, s.Prezime, s.Opstina != null ? s.Opstina.Naziv : " ");
            return Ok(response);
        }

        [HttpPost]
        public void Post(StudentAddRequest student)
        {
            int id = DatabaseContext.Studenti.Max(x => x.Id);
            var s = new Student
            {
                Id = id + 1,
                Ime = student.Ime,
                Prezime = student.Prezime,
                CreatedAt = DateTime.Now,
                OpstinaId = student.OpstinaId
            };
            DatabaseContext.Studenti.Add(s);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var s = DatabaseContext.Studenti.Find(x => x.Id == id);
            if (s == null)
                return NotFound();
            try
            {
                DatabaseContext.Studenti.Remove(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public List<StudentGetAllResponse> GetAll()
        {
            return DatabaseContext.Studenti.Select(x => new StudentGetAllResponse(x.Ime, x.Prezime)).ToList();
        }
    }
}