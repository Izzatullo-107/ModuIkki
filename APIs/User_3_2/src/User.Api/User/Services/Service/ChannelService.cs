using User.Api.User.DTO.ChannelDto;
using User.Api.User.Entiti;
using User.Api.User.Repository.InterfacesRepo;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Services.Controler;
using User.Api.User.Services.Interfes;

namespace User.Api.User.Services.Service;

public class ChannelService : IChannelService
{
    private readonly IChRepo ChRepos;

    public ChannelService()
    {
        ChRepos = new ChRepo();
    }

    //------------------------
    #region ToChGetDto/s
    private ChGetDto ToChGetDto(UserChannel channel)
    {
        return new ChGetDto()
        {
            ChannelId = channel.ChannelId,
            UserId = channel.UserId,
            ChannelName = channel.ChannelName,
            Description = channel.Description,
            Category = channel.Category,
            Subscribers = channel.Subscribers,
            CreatedDate = channel.CreatedDate,
            UpdatedDate = channel.UpdatedDate

        };
    }

    private List<ChGetDto> ToChGetDtos(List<UserChannel> channels)
    {
        var chGetDtos = new List<ChGetDto>();
        foreach (var channel in channels)
        {
            chGetDtos.Add(ToChGetDto(channel));
        }

        return chGetDtos;
    }
    #endregion
    //------------------------

    //{C}
    public Guid AddCh(ChCreatedDto user)
    {
        var newCh = new UserChannel
        {
            ChannelId = Guid.NewGuid(),
            UserId = user.UserId,
            ChannelName = user.ChannelName,
            Description = user.Description,
            Category = user.Category,
            Subscribers = 0,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow

        };
        return ChRepos.Add(newCh);
    }

    //{R}
    public ChGetDto? GetChById(Guid channelId)
    {
        var u = ChRepos.GetById(channelId);

        if (u == null) return null;

        return ToChGetDto(u);
    }
    public List<ChGetDto> GetAllChs()
    {
        var channels = ChRepos.GetAll();
        return ToChGetDtos(channels);
    }

    //{U}
    public bool UpdateCh(Guid chId, ChUpdateDto chUpdateDto)
    {
        var channel = ChRepos.GetById(chId);
        if (channel == null) return false;

        channel.ChannelId = channel.ChannelId;
        channel.ChannelName = chUpdateDto.ChannelName;
        channel.Description = chUpdateDto.Description;
        channel.Category = chUpdateDto.Category;
        channel.UpdatedDate = DateTime.UtcNow;
        channel.CreatedDate = channel.CreatedDate;
        channel.UserId = channel.UserId;
        channel.Subscribers = channel.Subscribers;
        ChRepos.Update(chId, channel);
        return true;
    }

    //{D}
    public bool DeleteCh(Guid chId)
    {
        if (ChRepos.GetById(chId) == null) return false;
        return ChRepos.Delete(chId);
    }

}
