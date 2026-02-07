using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Services.Interfes;
using User.Api.User.Services.Service;

namespace User.Api.Controllers;

[Route("api/video")]
[ApiController]
public class VideoController : ControllerBase
{
    private readonly IVideoService VideoService;

    public VideoController()
    {
        VideoService = new VideoService();
    }

    [HttpPost("create")]
    public Guid AddVideo(VideoCreatedDto video)
    {
        return VideoService.AddVideo(video);
    }

    [HttpGet("get-all")]
    public List<VideoGetDto> GetAllVideos()
    {
        return VideoService.GetAllVideos();
    }

    [HttpGet("get-by-id")]
    public VideoGetDto? GetVideoById(Guid videoId)
    {
        return VideoService.GetVideoById(videoId);
    }

    [HttpPut("update")]
    public bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto)
    {
        return VideoService.UpdateVideo(videoId, videoUpdateDto);
    }

    [HttpDelete("delete")]
    public bool DeleteVideo(Guid videoId)
    {
        return VideoService.DeleteVideo(videoId);
    }
}
