using Microsoft.Extensions.Hosting;
using System.Text.Json;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Entiti;
using User.Api.User.Repository.InterfacesRepo;

namespace User.Api.User.Repository.ServicesRepo;

public class VideoRepo : IVideoRepo
{

    private readonly string FilePath;
    public VideoRepo()
    {
        var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Videos.json");
        if (!File.Exists(FilePath))
        {
            var stream = File.Create(FilePath);
            stream.Close();
        }
    }

    public List<UserVideo>? GetAllVideos()
    {
        var json = File.ReadAllText(FilePath);
        if (string.IsNullOrEmpty(json))
        {
            return new List<UserVideo>();
        }

        var videos = JsonSerializer.Deserialize<List<UserVideo>>(json);
        return videos;
    }

    public void SaveAllVideos(List<UserVideo> videos)
    {
        var json = JsonSerializer.Serialize(videos);
        File.WriteAllText(FilePath, json);
    }


    //---------------------------------------------------------------------

    /*
    private List<UserVideo> VRepos;
    private readonly string FilePath;

    public VideoRepo()
    {
        FilePath = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Video_DB.json";
        VRepos = new List<UserVideo>();
    }

    //{C}
    public Guid Add(UserVideo video)
    {
        ReadVideosFromFile();
        VRepos.Add(video);
        SaveVideoToFile();
        return video.VideoId;
    }

    //{R}
    public UserVideo? GetById(Guid videoId)
    {
        ReadVideosFromFile();
        foreach (var video in VRepos)
        {
            if (video.VideoId == videoId)
            {
                return video;
            }
        }
        return null;
    }
    public List<UserVideo> GetAll()
    {
        ReadVideosFromFile();
        return VRepos;
    }

    //{U}
    public bool Update(Guid videoId, UserVideo videoUpdateDto)
    {
        ReadVideosFromFile();
        var existingVideo = GetById(videoId);
        if (existingVideo == null) return false;

        VRepos.Remove(existingVideo);
        VRepos.Add(videoUpdateDto);
        SaveVideoToFile();
        return true;
    }

    //{D}
    public bool Delete(Guid videoId)
    {
        ReadVideosFromFile();
        foreach (var video in VRepos)
        {
            if (video.VideoId == videoId)
            {
                VRepos.Remove(video);
                return true;
            }
        }
        SaveVideoToFile();
        return false;
    }


    #region File
    private void SaveVideoToFile()
    {
        var json = JsonSerializer.Serialize(VRepos);
        File.WriteAllText(FilePath, json);
    }

    private void ReadVideosFromFile()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            VRepos = new List<UserVideo>();
            return;
        }

        VRepos = JsonSerializer.Deserialize<List<UserVideo>>(json) ?? new List<UserVideo>();
    }
    #endregion

    */
}
