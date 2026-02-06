using User.Api.User.DTO.ChannelDto;

namespace User.Api.User.Services.Interfes;

public interface IChannelService
{
    public Guid AddUser(ChCreatedDto user);
    public ChGetDto? GetUserById(Guid userId);// bitta userni id  boyicha olish
    public List<ChGetDto> GetAllUsers();
    public bool UpdateUser(Guid userId, ChUpdateDto userUpdateDto);
    public bool DeleteUser(Guid userId);
}
