// using Microsoft.AspNetCore.Mvc;
// using TechMed.Application.ViewModels;
// using TechMed.Application.InputModels;
// using TechMed.Application.Services.Interfaces;

// namespace TechMed.WebAPI.Controllers;

// [ApiController]
// [Route("/api/v0.1/")]

// public class AtendimentoController : ControllerBase
// {
//    private readonly IAtendimentoService _atendimentoService;
//    public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll().ToList();
//    public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;
//    [HttpGet("atendimentos")]
//    public IActionResult Get()
//    {
//       return Ok(Atendimentos);

//    }



// }
