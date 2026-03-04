namespace User.Api.Users.Services.Interfes;

public interface ITokenService
{
    public (Guid userId, string role) GetTokenInfo(string token);
}
