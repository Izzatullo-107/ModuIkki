using Microsoft.EntityFrameworkCore.Metadata.Internal;
using User.Api.User.DTO.ChannelDto;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Entiti;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.InterfacesRepo;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Services.Interfes;
using User.Api.Users.Services.Interfes;
using User.Api.Users.Services.Service;

namespace User.Api.User.Services.Service;

public class VideoService : IVideoService
{

    private readonly IVideoRepo VideoRepository;
    private readonly ITokenService TokenService;
    private readonly IUserRepository UserRepository;
    private readonly IChRepo ChannelRepository;
    public VideoService()
    {
        VideoRepository = new VideoRepo();
        TokenService = new TokenService();
        UserRepository = new UserRepository();
        ChannelRepository = new ChRepo();
    }


    public Guid AddVideo(VideoCreatedDto videoCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return Guid.Empty;
        }

        var video = new UserVideo()
        {
            VideoId = Guid.NewGuid(),
            ChannelId = videoCreateDto.ChannelId,
            UserId = Guid.Parse(tokenResult.userId),
            VideoTitle = videoCreateDto.VideoTitle,
            Duration = videoCreateDto.Duration,
            LikesNumber = 0,
            DislikesNumber = 0,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,

        };

        var channelExists = false;
        var channels = ChannelRepository.GetAllChannels();

        foreach (var channel in channels)
        {
            if (channel.ChannelId == videoCreateDto.ChannelId && channel.UserId.ToString() == tokenResult.userId)
            {
                channelExists = true;
                break;
            }
        }
        
        if (channelExists == true)
        {
            return Guid.Empty;
        }

        if (channelExists == true)
        {
            var videos = VideoRepository.GetAllVideos();
            videos.Add(video);
            VideoRepository.SaveAllVideos(videos);
        }
        

        return video.VideoId;
    }

    public bool DeleteVideo(Guid videoId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return false;
        }

        var videos = VideoRepository.GetAllVideos();
        var videoToDelete = videos.FirstOrDefault(v => v.VideoId == videoId);

        if (videoToDelete != null)
        {
            // 2. Huquqni tekshiramiz (Egasi yoki Admin)
            bool isOwner = videoToDelete.UserId.ToString() == tokenResult.userId;
            bool isAdmin = tokenResult.role == "SupperAdmin";

            if (isOwner || isAdmin)
            {
                videos.Remove(videoToDelete);
                VideoRepository.SaveAllVideos(videos);
                return true;
            }
        }

        /*
        foreach (var video in videos)
        {
            if (video.VideoId == videoId && video.UserId.ToString() == tokenResult.userId
                || video.VideoId == videoId && tokenResult.role == "SupperAdmin")
            {
                videos.Remove(video);
                VideoRepository.SaveAllVideos(videos);
                return true;
            }
        }
        */

        return false;
    }

    public List<VideoGetDto> GetAllVideos(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var videoGetDtos = new List<VideoGetDto>();
        var videos = VideoRepository.GetAllVideos();



        //var countOfPosts = posts.Count(p => p.UserId.ToString() == tokenResult.userId);

        //var userPosts = posts.Where(p => p.UserId.ToString() == tokenResult.userId).ToList();

        //var userPostDtos = userPosts.Select(p => new PostGetDto()
        //{
        //    PostId = p.PostId,
        //    Title = p.Title,
        //    Content = p.Content,
        //    CreatedTime = p.CreatedTime,
        //    UpdatedTime = p.UpdatedTime,
        //    UserId = p.UserId
        //}).ToList();

        foreach (var video in videos)
        {
            if (video.UserId.ToString() == tokenResult.userId)
            {
                var videoGetDto = new VideoGetDto()
                {
                    VideoId = video.VideoId,
                    ChannelId = video.ChannelId,
                    UserId = video.UserId,
                    VideoTitle = video.VideoTitle,
                    Duration = video.Duration,
                    LikesNumber = video.LikesNumber,
                    DislikesNumber = video.DislikesNumber,
                    CreatedDate = video.CreatedDate,
                    UpdatedDate = video.UpdatedDate
                };
                videoGetDtos.Add(videoGetDto);
            }
        }

        //videoGetDtos = videoGetDtos.OrderBy(c => c.CreatedDate).ToList();
        //videoGetDtos = videoGetDtos.OrderByDescending(c => c.CreatedDate).ToList();

        return videoGetDtos;
    }

    public List<VideoGetDto>? GetAllVideosByAdmins(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        if (tokenResult.role == "User")
        {
            return null;
        }

        var videos = VideoRepository.GetAllVideos();

        var videoGetDtos = new List<VideoGetDto>();
        foreach (var video in videos)
        {
            var videoGetDto = new VideoGetDto()
            {
                VideoId = video.VideoId,
                ChannelId = video.ChannelId,
                UserId = video.UserId,
                VideoTitle = video.VideoTitle,
                Duration = video.Duration,
                LikesNumber = video.LikesNumber,
                DislikesNumber = video.DislikesNumber,
                CreatedDate = video.CreatedDate,
                UpdatedDate = video.UpdatedDate
            };
            videoGetDtos.Add(videoGetDto);
        }

        return videoGetDtos;
    }

    public VideoGetDto? GetVideoById(Guid videoId, string token)
    {
        var videos = VideoRepository.GetAllVideos();
        var tokenResult = TokenService.GetTokenInfo(token);
        var videoUserDto = new VideoGetDto();

        if (tokenResult.role == "User")
        {
            var userVideos = videos.Where(v => (v.VideoId == videoId)&&(v.UserId.ToString() == tokenResult.userId)).FirstOrDefault();
            videoUserDto = new VideoGetDto()
            {
                VideoId = userVideos.VideoId,
                ChannelId = userVideos.ChannelId,
                UserId = userVideos.UserId,
                VideoTitle = userVideos.VideoTitle,
                Duration = userVideos.Duration,
                LikesNumber = userVideos.LikesNumber,
                DislikesNumber = userVideos.DislikesNumber,
                CreatedDate = userVideos.CreatedDate,
                UpdatedDate = userVideos.UpdatedDate
            };

            if (videoUserDto == null)
            {
                return null;
            }
            return videoUserDto;
        }

        var videoDto = videos.Where(v => v.VideoId == videoId).FirstOrDefault();
        videoUserDto = new VideoGetDto()
        {
            VideoId = videoDto.VideoId,
            ChannelId = videoDto.ChannelId,
            UserId = videoDto.UserId,
            VideoTitle = videoDto.VideoTitle,
            Duration = videoDto.Duration,
            LikesNumber = videoDto.LikesNumber,
            DislikesNumber = videoDto.DislikesNumber,
            CreatedDate = videoDto.CreatedDate,
            UpdatedDate = videoDto.UpdatedDate
        };
        if (videoUserDto == null)
        {
            return null;
        }
        return videoUserDto;
    }

    public bool UpdateVideo(Guid videoId, VideoUpdateDto videoUpdateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return false;
        }

        var videos = VideoRepository.GetAllVideos();

        foreach (var video in videos)
        {
            if (video.VideoId == videoId && video.UserId.ToString() == tokenResult.userId)
            {
                video.VideoId = videoId;
                video.ChannelId = video.ChannelId;
                video.UserId = video.UserId;
                video.VideoTitle = videoUpdateDto.VideoTitle;
                video.Duration = video.Duration;
                video.UpdatedDate = DateTime.Now;
                video.CreatedDate = video.CreatedDate;
                video.LikesNumber = video.LikesNumber;
                video.DislikesNumber = video.DislikesNumber;
                VideoRepository.SaveAllVideos(videos);
                return true;
            }
        }

        return false;
    }


   
}
