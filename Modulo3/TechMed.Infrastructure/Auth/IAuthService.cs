namespace TechMed.Infrastructure.Auth;
public interface IAuthService
{
    string GerenateJwtToken(string username, string role);
    string ComputeSha256Hash(string pass);
}
