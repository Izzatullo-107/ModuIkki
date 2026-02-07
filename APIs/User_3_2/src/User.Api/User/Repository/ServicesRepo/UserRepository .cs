using System.Text.Json;
using User.Api.User.Entiti;
using User.Api.User.Repository.Interfaces;

namespace User.Api.User.Repository.ServicesRepo
{
    public class UserRepository : IUserRepository
    {
        private List<YouTubeUser> UsersRepo;
        private List<UserChannel> ChannelsRepo;
        private List<UserVideo> VideosRepo;
        private readonly string FilePath;
        private readonly string FilePathCh;
        private readonly string FilePathV;

        public UserRepository()
        {
            FilePath = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Data.json";
            FilePathCh = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Channel_DB.json";
            FilePathV = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Video_DB.json";

            UsersRepo = new List<YouTubeUser>();
            ChannelsRepo = new List<UserChannel>();
            VideosRepo = new List<UserVideo>();
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
            ReadUsersFromFile();
            ReadChannelsFromFile();
            ReadVideosFromFile();

            if (GetById(id) == null)
                return false;

            foreach (var user in UsersRepo)
            {
                if (user.UserId == id)
                {
                    foreach (var video in VideosRepo)
                    {
                        if (video.UserId == id)
                        {
                            VideosRepo.Remove(video);
                        }
                    }

                    foreach (var channel in ChannelsRepo)
                    {
                        if (channel.UserId == id)
                        {
                            ChannelsRepo.Remove(channel);
                        }
                    }

                    UsersRepo.Remove(user);
                    SaveUserToFile();
                    SaveChannelToFile();
                    SaveVideoToFile();

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

        #region FileChannel
        private void SaveChannelToFile()
        {
            var json = JsonSerializer.Serialize(ChannelsRepo);
            File.WriteAllText(FilePathCh, json);
        }

        private void ReadChannelsFromFile()
        {
            var json = File.ReadAllText(FilePathCh);

            if (string.IsNullOrEmpty(json))
            {
                ChannelsRepo = new List<UserChannel>();
                return;
            }

            ChannelsRepo = JsonSerializer.Deserialize<List<UserChannel>>(json) ?? new List<UserChannel>();
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
}
