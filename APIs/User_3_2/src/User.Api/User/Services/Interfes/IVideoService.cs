using User.Api.User.DTO.VideoDto;

namespace User.Api.User.Services.Interfes;

public interface IVideoService
{
    Guid AddVideo(VideoCreatedDto video);
    VideoGetDto? GetVideoById(Guid videoId);// bitta userni id  boyicha olish
    List<VideoGetDto> GetAllVideos();
    bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto);
    bool DeleteVideo(Guid videoId);
}
