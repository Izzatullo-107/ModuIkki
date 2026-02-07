using User.Api.User.DTO.ChannelDto;

namespace User.Api.User.Services.Interfes;

public interface IChannelService
{
    public Guid AddCh(ChCreatedDto user);
    public ChGetDto? GetChById(Guid userId);// bitta userni id  boyicha olish
    public List<ChGetDto> GetAllChs();
    public bool UpdateCh(Guid userId, ChUpdateDto userUpdateDto);
    public bool DeleteCh(Guid userId);
}
