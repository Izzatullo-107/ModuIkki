using User.Api.User.DTO.ChannelDto;

namespace User.Api.User.Services.Interfes;

public interface IChannelService
{
    Guid AddCh(ChCreatedDto user);
    ChGetDto? GetChById(Guid userId);// bitta userni id  boyicha olish
    List<ChGetDto> GetAllChs();
    bool UpdateCh(Guid userId, ChUpdateDto userUpdateDto);
    bool DeleteCh(Guid userId);
}
