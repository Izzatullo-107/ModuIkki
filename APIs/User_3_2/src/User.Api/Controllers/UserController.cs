using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.User.DTO.UserDto;
using User.Api.User.Services.Interfes;
using User.Api.User.Services.Service;

namespace User.Api.Controllers;
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService UserService;
    public UsersController()
    {
        UserService = new UserService();
    }

    [HttpPost("add")]
    public Guid AddUser(UserRegisterDto userRegisterDto)
    {
        return UserService.AddUser(userRegisterDto);
    }

    [HttpGet("get-all")]
    public List<UserGetDto>? GetAll(string token)
    {
        return UserService.GetAllUsers(token);
    }

    [HttpDelete("delete")]
    public bool DeleteUser(Guid userId, string token)
    {
        return UserService.DeleteUser(userId, token);
    }

    [HttpDelete("delete-user-channel")]
    public bool DeleteUserChannel(Guid channelId, string token)
    {
        return UserService.DeleteUserChannel(channelId, token);
    }

    [HttpPut("block")]
    public bool BlockUser(Guid userId, string token)
    {
        return UserService.BlockUser(userId, token);
    }

    [HttpPut("change-role")]
    public bool ChangeRole(Guid userId, string newRole, string token)
    {
        return UserService.ChangeRole(userId, newRole, token);

    }
}