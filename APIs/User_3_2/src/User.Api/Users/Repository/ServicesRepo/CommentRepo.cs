using System.Text.Json;
using User.Api.Users.Entiti;
using User.Api.Users.Repository.InterfacesRepo;

namespace User.Api.Users.Repository.ServicesRepo;

public class CommentRepo: ICommentRepo  
{
    private readonly string FilePath;
    public CommentRepo()
    {
        var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Comments.json");
        if (!File.Exists(FilePath))
        {
            var stream = File.Create(FilePath);
            stream.Close();
        }
    }
    public List<Comment>? GetAllComments()
    {
        var json = File.ReadAllText(FilePath);
        if (string.IsNullOrEmpty(json))
        {
            return new List<Comment>();
        }

        var comments = JsonSerializer.Deserialize<List<Comment>>(json);
        return comments;
    }

    public void SaveAllComments(List<Comment> comments)
    {
        var json = JsonSerializer.Serialize(comments);
        File.WriteAllText(FilePath, json);
    }
}
