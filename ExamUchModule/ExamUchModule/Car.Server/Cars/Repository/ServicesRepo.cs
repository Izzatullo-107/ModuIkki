using Car.Server.Cars.Dtos;
using Car.Server.Cars.Entiti;
using System.Text.Json;

namespace Car.Server.Cars.Repository;

public class ServicesRepo : IInterfacesRepo
{
    private readonly string FilePath;
    
    public ServicesRepo()
    {
        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Users.json");
        var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        // Data papkasining mavjudligini tekshirish va kerak bo'lsa yaratish
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Agar fayl mavjud bo'lmasa, uni yaratish
        if (!File.Exists(FilePath))
        {

            var stream = File.Create(FilePath);
            stream.Close();
        }
    }

    public List<GetDto>? GetAllUsers()
    {
        var json = File.ReadAllText(FilePath);

        if (string.IsNullOrEmpty(json))
        {
            return new List<Car>();
        }

        var users = JsonSerializer.Deserialize<List<GetDto>>(json);
        return users;
    }

    public void SaveAllUsers(List<CreateDto> users)
    {
        var json = JsonSerializer.Serialize(users);
        File.WriteAllText(FilePath, json);
    }
}
