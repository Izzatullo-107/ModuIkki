using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.ServicesRepo;
using User.Api.Users.Services.Interfes;

namespace User.Api.Users.Services.Service;

public class TokenService : ITokenService
{
    private readonly IUserRepository UserRepository;
    public TokenService()
    {
        UserRepository = new UserRepository();
    }
    public (Guid userId, string role) GetTokenInfo(string token)
    {
        var userId = Guid.Parse(token.Substring(0, 36));
        var role = token.Substring(36);

        return (userId, role);
    }
}
