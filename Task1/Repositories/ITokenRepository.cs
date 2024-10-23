using Microsoft.AspNetCore.Identity;
using Task1.Models.Domain;

namespace Task1.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(User user);
    }
}


