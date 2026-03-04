using User.Api.User.DTO.ChannelDto;

namespace User.Api.User.Services.Interfes;

public interface IChannelService
{
    public Guid AddChannel(ChCreatedDto channelCreateDto, string token);
    public List<ChGetDto> GetAllChannels(string token);
    public List<ChGetDto>? GetAllChannelsByAdmin(string token);
    public List<ChGetDto>? GetChannelById(Guid channelId, string token);
    public bool DeleteChannel(Guid channelId, string token);
    public bool UpdateChannel(Guid channelId, ChUpdateDto channelUpdateDto, string token);


    //-----------------------------------------------------------


    /*
    Guid AddCh(ChCreatedDto user);
    ChGetDto? GetChById(Guid userId);// bitta userni id  boyicha olish
    List<ChGetDto> GetAllChs();
    bool UpdateCh(Guid userId, ChUpdateDto userUpdateDto);
    bool DeleteCh(Guid userId);
    */
}
