using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services;


public class LoginService : ILoginService
{

    public LoginViewModel? Authenticate(LoginInputModel login)
    {

        // var passwordEncoded = 

        if (login.UserName == "admin" && login.Password == "admin")
        {
            return new LoginViewModel
            {
                Username = login.UserName,
                Token = "token",
            };
        }
        else
        {
            return null;
        }
    }
}


