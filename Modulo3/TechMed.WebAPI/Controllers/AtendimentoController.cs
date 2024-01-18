using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
  private readonly
  IOptions<OpeningTime> _openingTime;

  public AtendimentoController(
    IOptions<OpeningTime> openingTime)
  {
    _openingTime = openingTime;
  }

  [HttpGet("atendimentos")]
  public IActionResult Get()
  {
    var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
    {
      AtendimentoId = index,
      DataHora = DateTime.Now,
      MedicoId = index,
      Medico = new Medico
      {
        MedicoId = index,
        Nome = $"Medico {index}"
      }
    })
      .ToArray();
    return Ok(_openingTime.Value);
  }



}
