namespace TechMed.WebAPI;

public class Doctor
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public string? Name { get; set; }

    public Doctor()
    {
        Date = DateOnly.FromDateTime(DateTime.Now);
    }
}
