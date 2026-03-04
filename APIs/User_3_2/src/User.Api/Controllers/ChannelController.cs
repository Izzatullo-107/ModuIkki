using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.User.DTO.ChannelDto;
using User.Api.User.Services.Interfes;
using User.Api.User.Services.Service;

namespace User.Api.Controllers;

[Route("api/channels")]
[ApiController]
public class ChannelsController : ControllerBase
{
    private readonly IChannelService ChannelService;
    public ChannelsController()
    {
        ChannelService = new ChannelService();
    }

    [HttpPost("add")]
    public Guid AddChannel(ChCreatedDto channelCreateDto, string token)
    {
        return ChannelService.AddChannel(channelCreateDto, token);
    }

    [HttpGet("get-all")]
    public List<ChGetDto> GetAll(string token)
    {
        return ChannelService.GetAllChannels(token);
    }

    [HttpGet("get-all-by-admin")]
    public List<ChGetDto>? GetAllByAdmin(string token)
    {
        return ChannelService.GetAllChannelsByAdmin(token);
    }

    [HttpGet("get-by-id")]
    public List<ChGetDto>? GetById(Guid channelId, string token)
    {
        return ChannelService.GetChannelById(channelId, token);
    }

    [HttpPut("update")]
    public bool Update(Guid channelId, ChUpdateDto channelUpdateDto, string token)
    {
        return ChannelService.UpdateChannel(channelId, channelUpdateDto, token);
    }

    [HttpDelete("delete")]
    public bool Delete(Guid channelId, string token)
    {
        return ChannelService.DeleteChannel(channelId, token);
    }
}