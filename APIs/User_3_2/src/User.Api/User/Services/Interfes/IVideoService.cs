using User.Api.User.DTO.ChannelDto;
using User.Api.User.DTO.VideoDto;

namespace User.Api.User.Services.Interfes;

public interface IVideoService
{
    public Guid AddVideo(VideoCreatedDto video);
    public VideoGetDto? GetVideoById(Guid videoId);// bitta userni id  boyicha olish
    public List<VideoGetDto> GetAllVideos();
    public bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto);
    public bool DeleteVideo(Guid videoId);
}
