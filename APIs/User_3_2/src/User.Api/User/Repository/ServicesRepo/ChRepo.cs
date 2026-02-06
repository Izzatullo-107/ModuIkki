using System.Text.Json;
using User.Api.User.Entiti;
using User.Api.User.Repository.InterfacesRepo;

namespace User.Api.User.Repository.ServicesRepo;

public class ChRepo : IChRepo
{
    private List<UserChannel> ChRepos;
    private readonly string FilePath;

    public ChRepo()
    {
        FilePath = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Channel_DB.json";
        ChRepos = new List<UserChannel>();
    }

    //{C}
    public Guid Add(UserChannel user)
    {
        ReadUsersFromFile();
        ChRepos.Add(user);
        SaveUserToFile();
        return user.ChannelId;
    }

    //{R}
    public UserChannel? GetById(Guid id)
    {
        ReadUsersFromFile();
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
        ReadUsersFromFile();
        return ChRepos;
    }

    //{U}
    public bool Update(Guid id, UserChannel user)
    {
        ReadUsersFromFile();
        var existingUser = GetById(id);
        if (existingUser == null) return false;

        ChRepos.Remove(existingUser);
        ChRepos.Add(user);
        SaveUserToFile();
        return true;
    }

    //{D}
    public bool Delete(Guid id)
    {
        foreach (var channel in ChRepos)
        {
            if (channel.ChannelId == id)
            {
                ChRepos.Remove(channel);
                return true;
            }
        }
        return false;
    }

 
    #region File
    private void SaveUserToFile()
    {
        var json = JsonSerializer.Serialize(ChRepos);
        File.WriteAllText(FilePath, json);
    }

    private void ReadUsersFromFile()
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
}
