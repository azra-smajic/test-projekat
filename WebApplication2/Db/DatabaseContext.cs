using WebApplication2.Models;

namespace WebApplication2.Db
{
    public static class DatabaseContext
    {
        public static List<Opstina> Opstine = new List<Opstina>()
        {
            new Opstina()
            {
                Id = 1,
                Naziv = "Konjic",
                PostanskiBroj = "88400",
                CreatedAt = DateTime.Now,
            },
            new Opstina()
            {
                Id = 2,
                Naziv = "Mostar",
                PostanskiBroj = "88000",
                CreatedAt = DateTime.Now,
            }
        };

        public static List<Student> Studenti = new List<Student>() {
            new Student()
            {
                Id = 1,
                Ime = "Azra",
                Prezime = "Smajić",
                OpstinaId = 1,
                CreatedAt = DateTime.Now
            },
            new Student()
            {
                Id = 2,
                Ime = "Amir",
                Prezime = "Karaga",
                OpstinaId = 2,
                CreatedAt = DateTime.Now
            }
        };
    }
}