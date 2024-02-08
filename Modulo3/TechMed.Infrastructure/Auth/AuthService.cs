using System.Security.Cryptography;
using System.Text;

namespace TechMed.Infrastructure.Auth;
public class AuthService : IAuthService
{
    public string ComputeSha256Hash(string pass)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
    public string GerenateJwtToken(string username, string role)
    {
        throw new NotImplementedException();
    }
}
