using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
   private readonly ILoginService _loginService;
   public LoginController(ILoginService service) => _loginService = service;


   [HttpPost("login")]
   public IActionResult Login([FromBody] LoginInputModel user)
   {
      var userViewModel = _loginService.Authenticate(user);

      if (userViewModel is not null)
      {
         return Ok(userViewModel);

      }

      return Unauthorized();
   }

}
