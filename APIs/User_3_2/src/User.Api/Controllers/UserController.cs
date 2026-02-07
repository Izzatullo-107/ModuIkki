using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.User.DTO.UserDto;
using User.Api.User.Services.Interfes;
using User.Api.User.Services.Service;

namespace User.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService UserService;

    public UserController()
    {
        UserService = new UserService();
    }


    [HttpPost("create")]
    public Guid  AddUser(UserCreatedDto user)
    {
        return UserService.AddUser(user);
    }

    [HttpGet("get-all")]
    public List<UserGetDto> GetAllUsers()
    {
        return UserService.GetAllUsers();
    }

    [HttpGet("get-by-id")]
    public UserGetDto? GetUserById(Guid userId)
    {
        return UserService.GetUserById(userId);
    }

    [HttpPut("update")]
    public bool UpdateUser(Guid userId, UserUpdateDto userUpdateDto)
    {
        return UserService.UpdateUser(userId, userUpdateDto);
    }

    [HttpDelete("delete")]
    public bool DeleteUser(Guid userId)
    {
        return UserService.DeleteUser(userId);
    }
}
