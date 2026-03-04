using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.User.DTO.ChannelDto;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Services.Interfes;
using User.Api.User.Services.Service;

namespace User.Api.Controllers;

[Route("api/videos")]
[ApiController]
public class VideoController : ControllerBase
{
    private readonly IVideoService VideoService;

    public VideoController()
    {
        VideoService = new VideoService();
    }

    [HttpPost("add")]
    public Guid AddVideo(VideoCreatedDto video, string token)
    {
        return VideoService.AddVideo(video, token);
    }

    [HttpGet("get-all")]
    public List<VideoGetDto> GetAllVideos(string token)
    {
        return VideoService.GetAllVideos(token);
    }

    [HttpGet("get-all-by-admin")]
    public List<VideoGetDto>? GetAllByAdmin(string token)
    {
        return VideoService.GetAllVideosByAdmins(token);
    }

    [HttpGet("get-by-id")]
    public VideoGetDto? GetVideoById(Guid videoId, string token)
    {
        return VideoService.GetVideoById(videoId, token);
    }

    [HttpPut("update")]
    public bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto, string token)
    {
        return VideoService.UpdateVideo(videoId, videoUpdateDto, token);
    }

    [HttpDelete("delete")]
    public bool DeleteVideo(Guid videoId, string token)
    {
        return VideoService.DeleteVideo(videoId, token);
    }
}
