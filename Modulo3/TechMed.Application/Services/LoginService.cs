using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Auth;

namespace TechMed.Application.Services;


public class LoginService : ILoginService
{
    private readonly IAuthService _authService;

    public LoginService(IAuthService authService)
    {
        _authService = authService;
    }

    public LoginViewModel? Authenticate(LoginInputModel login)
    {

        string passHashed = _authService.ComputeSha256Hash(login.Password);

        if (login.UserName == "admin" && passHashed == _authService.ComputeSha256Hash("admin"))
        {
            string token = _authService.GenerateJwtToken(login.UserName, "admin");

            return new LoginViewModel
            {
                Username = login.UserName,
                Token = token,
            };
        }

        return null;
    }
}


