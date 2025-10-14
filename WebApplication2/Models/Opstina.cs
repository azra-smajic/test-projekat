namespace WebApplication2.Models
{
    public class Opstina
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}