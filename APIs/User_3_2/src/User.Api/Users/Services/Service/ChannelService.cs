using User.Api.User.DTO.ChannelDto;
using User.Api.User.Entiti;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.InterfacesRepo;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Services.Interfes;
using User.Api.Users.Services.Interfes;
using User.Api.Users.Services.Service;

namespace User.Api.User.Services.Service;

public class ChannelService : IChannelService
{
    private readonly IChRepo ChannelRepository;
    private readonly ITokenService TokenService;
    private readonly IUserRepository UserRepository;
    public ChannelService()
    {
        ChannelRepository = new ChRepo();
        TokenService = new TokenService();
        UserRepository = new UserRepository();
    }


    public Guid AddChannel(ChCreatedDto channelCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);


        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return Guid.Empty;
        }

        var channel = new UserChannel()
        {
            ChannelId = Guid.NewGuid(),
            UserId = Guid.Parse(tokenResult.userId),
            ChannelName = channelCreateDto.ChannelName,
            Description = channelCreateDto.Description,
            Category = channelCreateDto.Category,
            Subscribers = 0,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,

        };

        var userExists = false;
        var users = UserRepository.GetAllUsers();
        foreach (var user in users)
        {
            if (user.UserId.ToString() == tokenResult.userId)
            {
                userExists = true;
                break;
            }
        }

        if (userExists == true)
        {
            var channels = ChannelRepository.GetAllChannels();
            channels.Add(channel);
            ChannelRepository.SaveAllChannels(channels);
        }

        return channel.ChannelId;
    }

    public bool DeleteChannel(Guid channelId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return false;
        }

        var channels = ChannelRepository.GetAllChannels();

        foreach (var channel in channels)
        {
            if (channel.ChannelId == channelId && channel.UserId.ToString() == tokenResult.userId)
            {
                channels.Remove(channel);
                ChannelRepository.SaveAllChannels(channels);
                return true;
            }
        }

        return false;
    }

    public List<ChGetDto> GetAllChannels(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var channelGetDtos = new List<ChGetDto>();

        var channels = ChannelRepository.GetAllChannels();

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

        foreach (var channel in channels)
        {
            if (channel.UserId.ToString() == tokenResult.userId)
            {
                var channelGetDto = new ChGetDto()
                {
                    ChannelId = channel.ChannelId,
                    UserId = channel.UserId,
                    ChannelName = channel.ChannelName,
                    Description = channel.Description,
                    Category = channel.Category,
                    Subscribers = channel.Subscribers,
                    CreatedTime = channel.CreatedDate,
                    UpdatedTime = channel.UpdatedDate
                };
                channelGetDtos.Add(channelGetDto);
                //break;
            }
        }

        channelGetDtos = channelGetDtos.OrderBy(c => c.CreatedTime).ToList();
        //channelGetDtos = channelGetDtos.OrderByDescending(c => c.CreatedTime).ToList();


        return channelGetDtos;
    }

    public List<ChGetDto>? GetAllChannelsByAdmin(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        if (tokenResult.role == "User")
        {
            return null;
        }

        var channels = ChannelRepository.GetAllChannels();

        var channelGetDtos = new List<ChGetDto>();
        foreach (var channel in channels)
        {
            var channelGetDto = new ChGetDto()
            {
                ChannelId = channel.ChannelId,
                UserId = channel.UserId,
                ChannelName = channel.ChannelName,
                Description = channel.Description,
                Category = channel.Category,
                Subscribers = channel.Subscribers,
                CreatedTime = channel.CreatedDate,
                UpdatedTime = channel.UpdatedDate
            };
            channelGetDtos.Add(channelGetDto);
        }

        return channelGetDtos;
    }
    public List<ChGetDto>? GetChannelById(Guid channelId, string token)
    {
        var channels = ChannelRepository.GetAllChannels();
        var tokenResult = TokenService.GetTokenInfo(token);
        var channelUserDto = new List<ChGetDto>();

        if (tokenResult.role == "User")
        {
            var channelUser = channels.Where(ch => ch.ChannelId == channelId && ch.UserId.ToString() == tokenResult.userId).ToList();
             channelUserDto = channelUser.Select(ch => new ChGetDto()
            {
                ChannelId = ch.ChannelId,
                UserId = ch.UserId,
                ChannelName = ch.ChannelName,
                Description = ch.Description,
                Category = ch.Category,
                Subscribers = ch.Subscribers,
                CreatedTime = ch.CreatedDate,
                UpdatedTime = ch.UpdatedDate
            }).ToList();
            if (channelUserDto.Count == 0)
            {
                return null;
            }
           return channelUserDto;
        }
        var channelDto = channels.Where(ch => ch.ChannelId == channelId).ToList();
        channelUserDto = channelDto.Select(ch => new ChGetDto()
        {
            ChannelId = ch.ChannelId,
            UserId = ch.UserId,
            ChannelName = ch.ChannelName,
            Description = ch.Description,
            Category = ch.Category,
            Subscribers = ch.Subscribers,
            CreatedTime = ch.CreatedDate,
            UpdatedTime = ch.UpdatedDate
        }).ToList();
        return channelUserDto;
    }

    public bool UpdateChannel(Guid channelId, ChUpdateDto channelUpdateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return false;
        }

        var channels = ChannelRepository.GetAllChannels();

        foreach (var channel in channels)
        {
            if (channel.ChannelId == channelId && channel.UserId.ToString() == tokenResult.userId)
            {
                channel.ChannelName = channelUpdateDto.ChannelName;
                channel.Description = channelUpdateDto.Description;
                channel.Category = channelUpdateDto.Category;
                channel.UpdatedDate = DateTime.Now;
                channel.CreatedDate= channel.CreatedDate;
                ChannelRepository.SaveAllChannels(channels);
                return true;
            }
        }

        return false;
    }

}
