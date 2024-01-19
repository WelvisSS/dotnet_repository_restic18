// using Microsoft.AspNetCore.Mvc;
// using TechMed.WebAPI.Infra.Data.Interfaces;
// using TechMed.WebAPI.Model;

// namespace TechMed.WebAPI.Controllers;

// [ApiController]
// [Route("/api/v0.1/")]
// public class ExameController : ControllerBase
// {
//     private readonly IExameCollection _exame;
//     public List<Atendimento> Atendimentos => _exame.GetAll().ToList();
//     public AtendimentoController(IAtendimentoCollection atendimentos) => _atendimento = atendimentos;

//     [HttpGet("atendimentos")]
//     public IActionResult Get()
//     {
//         return Ok(Atendimentos);
//     }

//     [HttpGet("atendimento/{id}")]
//     public IActionResult GetById(int id)
//     {
//         var atendimento = _atendimento.GetById(id);
//         return Ok(atendimento);
//     }

//     [HttpPost("atendimento")]
//     public IActionResult Post([FromBody] Atendimento atendimento)
//     {
//         _atendimento.Create(atendimento);
//         return CreatedAtAction(nameof(Get), atendimento);
//     }

//     [HttpPut("atendimento/{id}")]
//     public IActionResult Put(int id, [FromBody] Atendimento atendimento)
//     {
//         if (_atendimento.GetById(id) == null)
//             return NoContent();
//         _atendimento.Update(id, atendimento);
//         return Ok(_atendimento.GetById(id));
//     }

//     [HttpDelete("atendimento/{id}")]
//     public IActionResult Delete(int id)
//     {
//         if (_atendimento.GetById(id) == null)
//             return NoContent();
//         _atendimento.Delete(id);
//         return Ok();
//     }

//     // [HttpGet("medico/{id}/atendimentos")]
//     // public IActionResult GetAtendimentos(int id)
//     // {
//     //    var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
//     //      {
//     //          AtendimentoId = index,
//     //          DataHora = DateTime.Now,
//     //          MedicoId = id,
//     //          Medico = new Medico
//     //          {
//     //              MedicoId = id,
//     //              Nome = $"Medico {id}"
//     //          }
//     //      })
//     //      .ToArray();
//     //    return Ok(atendimento);
//     // }
// }
