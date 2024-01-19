using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteCollection _paciente;
    public List<Paciente> Paciente => _paciente.GetAll().ToList();
    public PacienteController(IPacienteCollection paciente) => _paciente = paciente;

    [HttpGet("pacientes")]
    public IActionResult Get()
    {
        return Ok(Paciente);
    }

    [HttpGet("paciente/{id}")]
    public IActionResult GetById(int id)
    {
        var medico = _paciente.GetById(id);
        return Ok(medico);
    }

    [HttpPost("paciente")]
    public IActionResult Post([FromBody] Paciente paciente)
    {
        _paciente.Create(paciente);
        return CreatedAtAction(nameof(Get), paciente);
    }

    [HttpPut("paciente/{id}")]
    public IActionResult Put(int id, [FromBody] Paciente paciente)
    {
        if (_paciente.GetById(id) == null)
            return NoContent();
        _paciente.Update(id, paciente);
        return Ok(_paciente.GetById(id));
    }

    [HttpDelete("paciente/{id}")]
    public IActionResult Delete(int id)
    {
        if (_paciente.GetById(id) == null)
            return NoContent();
        _paciente.Delete(id);
        return Ok();
    }

    // [HttpGet("medico/{id}/atendimentos")]
    // public IActionResult GetAtendimentos(int id)
    // {
    //    var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
    //      {
    //          AtendimentoId = index,
    //          DataHora = DateTime.Now,
    //          MedicoId = id,
    //          Medico = new Medico
    //          {
    //              MedicoId = id,
    //              Nome = $"Medico {id}"
    //          }
    //      })
    //      .ToArray();
    //    return Ok(atendimento);
    // }
}

