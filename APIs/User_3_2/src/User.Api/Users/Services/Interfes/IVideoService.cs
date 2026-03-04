using User.Api.User.DTO.ChannelDto;
using User.Api.User.DTO.VideoDto;

namespace User.Api.User.Services.Interfes;

public interface IVideoService
{
    public Guid AddVideo(VideoCreatedDto videoCreateDto, string token);
    public List<VideoGetDto> GetAllVideos(string token);
    public List<VideoGetDto>? GetAllVideosByAdmins(string token);
    public VideoGetDto? GetVideoById(Guid videoId, string token);
    public bool DeleteVideo(Guid videoId, string token);
    public bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto, string token);


    //-----------------------------------------------------------


    /*
    Guid AddVideo(VideoCreatedDto video);
    VideoGetDto? GetVideoById(Guid videoId);// bitta userni id  boyicha olish
    List<VideoGetDto> GetAllVideos();
    bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto);
    bool DeleteVideo(Guid videoId);
    */
}
