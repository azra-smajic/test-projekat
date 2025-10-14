namespace WebApplication2.Dtos
{
    public record StudentGetByIdResponse(
        int id,
        string ime,
        string prezime,
        string opstinaNaziv
        );
}