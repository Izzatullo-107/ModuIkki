using System.Text.Json;
using User.Api.User.Entiti;
using User.Api.User.Repository.InterfacesRepo;

namespace User.Api.User.Repository.ServicesRepo;

public class ChRepo : IChRepo
{
    private List<UserChannel> ChRepos;
    private List<UserVideo> VideosRepo;
    private readonly string FilePath;
    private readonly string FilePathV;

    public ChRepo()
    {
        FilePath = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Channel_DB.json";
        FilePathV = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Video_DB.json";

        ChRepos = new List<UserChannel>();
        VideosRepo = new List<UserVideo>();
    }

    //{C}
    public Guid Add(UserChannel user)
    {
        ReadChannelsFromFile();
        ChRepos.Add(user);
        SaveChannelToFile();
        return user.ChannelId;
    }

    //{R}
    public UserChannel? GetById(Guid id)
    {
        ReadChannelsFromFile();
        foreach (var channel in ChRepos)
        {
            if (channel.ChannelId == id)
            {
                return channel;
            }
        }
        return null;
    }
    public List<UserChannel> GetAll()
    {
        ReadChannelsFromFile();
        return ChRepos;
    }

    //{U}
    public bool Update(Guid id, UserChannel userCh)
    {
        ReadChannelsFromFile();
        var existingChannel = GetById(id);
        if (existingChannel == null) return false;

        ChRepos.Remove(existingChannel);
        ChRepos.Add(userCh);
        SaveChannelToFile();
        return true;
    }

    //{D}
    public bool Delete(Guid id)
    {

        ReadChannelsFromFile();
        foreach (var channel in ChRepos)
        {
            if (channel.ChannelId == id)
            {
                foreach (var video in VideosRepo)
                {
                    if (video.ChannelId == id)
                    {
                        VideosRepo.Remove(video);
                    }
                }

                ChRepos.Remove(channel);
                SaveChannelToFile();
                SaveVideoToFile();

                return true;
            }
        }
       
        return false;
    }

 
    #region File
    private void SaveChannelToFile()
    {
        var json = JsonSerializer.Serialize(ChRepos);
        File.WriteAllText(FilePath, json);
    }

    private void ReadChannelsFromFile()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            ChRepos = new List<UserChannel>();
            return;
        }

        ChRepos = JsonSerializer.Deserialize<List<UserChannel>>(json) ?? new List<UserChannel>();
    }
    #endregion

    #region FileVideo
    private void SaveVideoToFile()
    {
        var json = JsonSerializer.Serialize(VideosRepo);
        File.WriteAllText(FilePathV, json);
    }

    private void ReadVideosFromFile()
    {
        var json = File.ReadAllText(FilePathV);

        if (string.IsNullOrEmpty(json))
        {
            VideosRepo = new List<UserVideo>();
            return;
        }

        VideosRepo = JsonSerializer.Deserialize<List<UserVideo>>(json) ?? new List<UserVideo>();
    }
    #endregion
}
