using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v1.0/doctors")]
public class DoctorsController : ControllerBase
{
    private static readonly string[] DoctorsName = new[]
    {
        "Dr. Pedro", "Dr. Paulo", "Dr. José", "Dr. Marcelo", "Dr. Enrique", "Dr. Gustavo", "Dr. Fernando", "Dr. Paulo"
    };

    public List<Doctor> doctorsList = new List<Doctor>();

    private readonly ILogger<DoctorsController> _logger;

    public DoctorsController(ILogger<DoctorsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDoctors")]
    public IEnumerable<Doctor> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Doctor
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Name = DoctorsName[Random.Shared.Next(DoctorsName.Length)],
        })
        .ToArray();
    }


    [HttpGet("pi/v1.0/doctors/{id}", Name = "GetDoctorById")]
    public IActionResult GetDoctorById(int id)
    {
        Doctor doctor = new Doctor();
        doctor.Id = new Guid(id.ToString());
        doctor.Name = "Dr. Augusto";
        return Ok(doctor);
    }


    [HttpDelete("pi/v1.0/doctors/{id}", Name = "DeleteDoctor")]
    public IActionResult Delete(int id)
    {
        return Ok("Deletado");
    }

    [HttpPut("pi/v1.0/doctors/{id}", Name = "UpdateDoctor")]
    public IActionResult Update(int id)
    {
        return Ok("Atualizado");
    }

    [HttpPost(Name = "PostDoctor")]
    public IActionResult Post([FromBody] Doctor doctor)
    {
        return Ok(doctor);
    }
}
