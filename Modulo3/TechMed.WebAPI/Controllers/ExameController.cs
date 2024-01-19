using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameController : ControllerBase
{
    private readonly IExameCollection _exame;
    public List<Exame> Exames => _exame.GetAll().ToList();
    public ExameController(IExameCollection exames) => _exame = exames;

    [HttpGet("exames")]
    public IActionResult Get()
    {
        return Ok(Exames);
    }

    [HttpGet("exames/{id}")]
    public IActionResult GetById(int id)
    {
        var exame = _exame.GetById(id);
        return Ok(exame);
    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] Exame exame)
    {
        _exame.Create(exame);
        return CreatedAtAction(nameof(Get), exame);
    }

    [HttpPut("exame/{id}")]
    public IActionResult Put(int id, [FromBody] Exame exame)
    {
        if (_exame.GetById(id) == null)
            return NoContent();
        _exame.Update(id, exame);
        return Ok(_exame.GetById(id));
    }

    [HttpDelete("exame/{id}")]
    public IActionResult Delete(int id)
    {
        if (_exame.GetById(id) == null)
            return NoContent();
        _exame.Delete(id);
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
