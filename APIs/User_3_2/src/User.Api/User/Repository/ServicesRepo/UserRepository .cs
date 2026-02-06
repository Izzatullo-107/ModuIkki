using System.CodeDom;
using System.Text.Json;
using User.Api.User.Entiti;
using User.Api.User.Repository.Interfaces;

namespace User.Api.User.Repository.ServicesRepo
{
    public class UserRepository : IUserRepository
    {
        private List<YouTubeUser> UsersRepo;
        private readonly string FilePath;

        public UserRepository()
        {
            FilePath = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Data.json";

            UsersRepo = new List<YouTubeUser>();
        }

        //{C}
        public Guid Add(YouTubeUser user)
        {
            ReadUsersFromFile();
            UsersRepo.Add(user);
            SaveUserToFile();
            return user.UserId;
        }

        //{R}
        public YouTubeUser? GetById(Guid id)
        {
            ReadUsersFromFile();
            foreach (var user in UsersRepo)
            {
                if (user.UserId == id)
                {
                    return user;
                }
            }
            return null;
        }
        public List<YouTubeUser> GetAll()
        {
            ReadUsersFromFile();
            return UsersRepo;
        }

        //{U}
        public bool Update(Guid id, YouTubeUser user)
        {
            ReadUsersFromFile();
            var existingUser = GetById(id);
            if (existingUser == null) return false;

            UsersRepo.Remove(existingUser);
            UsersRepo.Add(user);
            SaveUserToFile();
            return true;
        }

        //{D}
        public bool Delete(Guid id)
        {
            foreach (var user in UsersRepo)
            {
                if (user.UserId == id)
                {
                    UsersRepo.Remove(user);
                    return true;
                }
            }
            return false;
        }

        #region File
        private void SaveUserToFile()
        {
            var json = JsonSerializer.Serialize(UsersRepo);
            File.WriteAllText(FilePath, json);
        }

        private void ReadUsersFromFile()
        {
            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrEmpty(json))
            {
                UsersRepo = new List<YouTubeUser>();
                return;
            }

            UsersRepo = JsonSerializer.Deserialize<List<YouTubeUser>>(json) ?? new List<YouTubeUser>();
        }
        #endregion

    }
}
