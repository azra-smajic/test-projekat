using Microsoft.AspNetCore.Mvc;
using WebApplication2.Db;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(DatabaseContext databaseContext) : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<StudentGetByIdResponse> GetById(int id)
        {
            var s = databaseContext.Studenti.ToList().Find(x => x.Id == id);
            var response = new StudentGetByIdResponse(s.Id, s.Ime, s.Prezime, s.Opstina != null ? s.Opstina.Naziv : " ");
            return Ok(response);
        }

        [HttpPost]
        public void Post(StudentAddRequest student)
        {
            var s = new Student
            {
                Ime = student.Ime,
                Prezime = student.Prezime,
                CreatedAt = DateTime.Now,
                OpstinaId = student.OpstinaId
            };
            databaseContext.Studenti.Add(s);
            databaseContext.SaveChanges();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var s = databaseContext.Studenti.ToList().Find(x => x.Id == id);
            if (s == null)
                throw new Exception("Student nije pronadjen");
            try
            {
                databaseContext.Studenti.Remove(s);
                databaseContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public List<StudentGetAllResponse> GetAll(string? ime, string? nazivOpstine)
        {
            var studentiQuery = databaseContext.Studenti.AsQueryable();

            if (!string.IsNullOrWhiteSpace(ime))
                studentiQuery = studentiQuery.Where(x => x.Ime.ToLower().StartsWith(ime.ToLower()));

            if (!string.IsNullOrWhiteSpace(nazivOpstine))
                studentiQuery = studentiQuery.Where(x => x.Opstina.Naziv.ToLower().StartsWith(nazivOpstine.ToLower()));

            return studentiQuery.Select(x => new StudentGetAllResponse(x.Ime, x.Prezime)).ToList();
        }
    }
}