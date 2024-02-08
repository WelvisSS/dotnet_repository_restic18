using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
   private readonly ILoginService _authService;
   public LoginController(ILoginService service) => _authService = service;


   [HttpPost("authenticate")]
   public IActionResult Login([FromBody] LoginInputModel user)
   {
      var token = _authService.Authenticate(user);
      if (token == null)
      {
         return Unauthorized();
      }
      return Ok(new { Token = token });
   }


}
