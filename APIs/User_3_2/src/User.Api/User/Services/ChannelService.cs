using User.Api.User.DTO.ChannelDto;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.InterfacesRepo;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Services.Interfes;

namespace User.Api.User.Services;

public class ChannelService : IChannelService
{
    private readonly IChRepo ChRepos;

    public ChannelService()
    {
        ChRepos = new ChRepo();
    }

    public Guid AddUser(ChCreatedDto user)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public List<ChGetDto> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public ChGetDto? GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateUser(Guid userId, ChUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }
}
