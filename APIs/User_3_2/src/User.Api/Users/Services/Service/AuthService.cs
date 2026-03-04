using User.Api.User.DTO.UserDto;
using User.Api.User.Entiti;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.ServicesRepo;

namespace User.Api.Users.Services.Service;

public class AuthService
{

    private readonly IUserRepository UserRepository;
    public AuthService()
    {
        UserRepository = new UserRepository();
    }

    public string LoginUser(UserLoginDto userLoginDto)
    {
        var users = UserRepository.GetAllUsers();

        foreach (var user in users)
        {
            if (user.NickName == userLoginDto.UserName
                && user.Password == userLoginDto.Password)
            {
                return user.UserId.ToString() + user.Position;
            }
        }

        return "User yoki parol xato";
    }

    public Guid RegisterUser(UserRegisterDto userRegisterDto)
    {
        var user = new YouTubeUser()
        {
            UserId = Guid.NewGuid(),
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            NickName = userRegisterDto.UserName,
            Password = userRegisterDto.Password,
            Position = "User",
            UserBlocked = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow

        };

        var users = UserRepository.GetAllUsers();

        users.Add(user);

        UserRepository.SaveAllUsers(users);

        return user.UserId;
    }

}
