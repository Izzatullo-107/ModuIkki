using System.Threading.Channels;
using User.Api.User.DTO.ChannelDto;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Entiti;
using User.Api.User.Repository.InterfacesRepo;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Services.Interfes;

namespace User.Api.User.Services.Service;

public class VideoService : IVideoService
{
    private readonly IVideoRepo VRepos;

    public VideoService()
    {
        VRepos = new VideoRepo();
    }

    //
    //----------------------------
    #region ToVideoGetDto/s
    private VideoGetDto ToVideoGetDto(UserVideo video)
    {
        return new VideoGetDto()
        {
            VideoId = video.VideoId,
            ChannelId = video.ChannelId,
            UserId = video.UserId,
            VideoTitle = video.VideoTitle,
            Duration = video.Duration,
            CreatedDate = video.CreatedDate,
            UpdatedDate = video.UpdatedDate,
            LikesNumber = video.LikesNumber,
            DislikesNumber = video.DislikesNumber
        };
    }

    private List<VideoGetDto> ToVideoGetDtos(List<UserVideo> videos)
    {
        var videoGetDtos = new List<VideoGetDto>();
        foreach (var video in videos)
        {
            videoGetDtos.Add(ToVideoGetDto(video));
        }

        return videoGetDtos;
    }
    #endregion
    //----------------------------
    //

    //{C}
    public Guid AddVideo(VideoCreatedDto video)
    {
        var newVideo = new UserVideo
        {
            VideoId = Guid.NewGuid(),
            ChannelId = video.ChannelId,
            UserId = video.UserId,
            VideoTitle = video.VideoTitle,
            Duration = video.Duration,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            LikesNumber = 0,    
            DislikesNumber = 0

        };
        return VRepos.Add(newVideo);
    }

    //{R}
    public VideoGetDto? GetVideoById(Guid videoId)
    {
        var video = VRepos.GetById(videoId);
        if (video == null) return null;

        return ToVideoGetDto(video);
    }
    public List<VideoGetDto> GetAllVideos()
    {
        var videos = VRepos.GetAll();
        return ToVideoGetDtos(videos);
    }

    //{U}
    public bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto)
    {
        var video = VRepos.GetById(videoId);
        if (video == null) return false;

        video.VideoId = videoId;
        video.ChannelId = video.ChannelId;
        video.UserId = video.UserId;
        video.VideoTitle = videoUpdateDto.VideoTitle;
        video.Duration = video.Duration;
        video.CreatedDate = video.CreatedDate;
        video.UpdatedDate = DateTime.UtcNow;
        video.LikesNumber = video.LikesNumber;
        video.DislikesNumber = video.DislikesNumber;

        VRepos.Update(videoId, video);
        return true;
    }

    //{D}
    public bool DeleteVideo(Guid videoId)
    {
        if (VRepos.GetById(videoId) == null) return false;
        VRepos.Delete(videoId);

        return true;
    }
}
