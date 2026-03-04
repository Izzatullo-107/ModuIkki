using User.Api.User.DTO.UserDto;

namespace User.Api.Users.Services.Interfes;

public interface IAuthService
{
    public Guid RegisterUser(UserRegisterDto userRegisterDto);
    public string LoginUser(UserLoginDto userLoginDto);
}
