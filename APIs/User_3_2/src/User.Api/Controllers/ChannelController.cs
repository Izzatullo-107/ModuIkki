using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.User.DTO.ChannelDto;
using User.Api.User.Services.Interfes;
using User.Api.User.Services.Service;

namespace User.Api.Controllers;

[Route("api/channel")]
[ApiController]
public class ChannelController : ControllerBase
{
    private readonly IChannelService ChannelService;

    public ChannelController()
    {
        ChannelService = new ChannelService();
    }

    [HttpPost("create")]
    public Guid AddChannel(ChCreatedDto channel)
    {
        return ChannelService.AddCh(channel);
    }

    [HttpGet("get-all")]
    public List<ChGetDto> GetAllChannels()
    {
        return ChannelService.GetAllChs();
    }

    [HttpGet("get-by-id")]
    public ChGetDto? GetChannelById(Guid channelId)
    {
        return ChannelService.GetChById(channelId);
    }

    [HttpPut("update")]
    public bool UpdateChannel(Guid channelId, ChUpdateDto channelUpdateDto)
    {
        return ChannelService.UpdateCh(channelId, channelUpdateDto);
    }

    [HttpDelete("delete")]
    public bool DeleteChannel(Guid channelId)
    {
        return ChannelService.DeleteCh(channelId);
    }
}
