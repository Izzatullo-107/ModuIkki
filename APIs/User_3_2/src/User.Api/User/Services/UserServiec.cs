using Microsoft.Extensions.Hosting;
using System.Text.Json;
using User.Api.User.DTO;
using User.Api.User.Entiti;
using User.Api.User.Services.Interfes;

namespace User.Api.User.Services
{
    public class UserServiec : IUserService

    {
        private List<YouTubeUser> Users;
        // readonly vs const
        private readonly string FilePath;

        public UserServiec()
        {

            FilePath = "D:\\Users\\DotNet\\ModuIkki\\APIs\\User_3_2\\src\\User.Api\\User\\AppDBContext\\Data.json";
            Users = new List<YouTubeUser>();
        }

        //
        // ---------------------------------------
        #region ToUserGetDto/s
        private UserGetDto ToUserGetDto(YouTubeUser user)
        {
            return new UserGetDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NickName = user.NickName,
                ChannelName = user.ChannelName,
                Subscribers = user.Subscribers,
                Durations = user.Durations,
                LikesNumber = user.LikesNumber,
                DislikesNumber = user.DislikesNumber

            };
        }

        private List<UserGetDto> ToUserGetDtos(List<YouTubeUser> users)
        {
            var userGetDtos = new List<UserGetDto>();
            foreach (var user in users)
            {
                userGetDtos.Add(ToUserGetDto(user));
            }

            return userGetDtos;
        }
        #endregion
        // ---------------------------------------
        #region FileOperations
        private void SaveUserToFile()
        {
            var json = JsonSerializer.Serialize(Users);
            File.WriteAllText(FilePath, json);
        }

        private void ReadUsersFromFile()
        {
            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrEmpty(json))
            {
                Users = new List<YouTubeUser>();
                return;
            }

            Users = JsonSerializer.Deserialize<List<YouTubeUser>>(json) ?? new List<YouTubeUser>();
        }


        #endregion ////////////////////////////////////////////////////////////////////////////////////// 
        // ---------------------------------------
        //

        //{C}
        public Guid AddUser(UserCreatedDto user)
        {
            var newUser = new YouTubeUser
            {
                UserId = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                NickName = user.NickName,
                Password = user.Password,
                ChannelName = user.ChannelName,
                Subscribers = user.Subscribers,
                Durations = user.Durations,
                LikesNumber = 0,
                DislikesNumber = 0
            };
            Users.Add(newUser);
            SaveUserToFile();
            return newUser.UserId;

        }

        //{R}
        public UserGetDto? GetUserById(Guid userId)
        {
            ReadUsersFromFile();
            foreach (var u in Users)
            {
                if (u.UserId == userId)
                {
                    return new UserGetDto()
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        NickName = u.NickName,
                        ChannelName = u.ChannelName,
                        Subscribers = u.Subscribers,
                        Durations = u.Durations,
                        LikesNumber = u.LikesNumber,
                        DislikesNumber = u.DislikesNumber
                    };
                }
            }

            return null;

        }
        
        public List<UserGetDto> GetAllUsers()
        {
            ReadUsersFromFile();
            List<UserGetDto> userGetDtos = new List<UserGetDto>();
            foreach (var u in Users)
            {
                userGetDtos.Add(new UserGetDto()
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    NickName = u.NickName,
                    ChannelName = u.ChannelName,
                    Subscribers = u.Subscribers,
                    Durations = u.Durations,
                    LikesNumber = u.LikesNumber,
                    DislikesNumber = u.DislikesNumber
                });
            }

            return userGetDtos;


            /*
            var ListToUserGetDto = ToUserGetDtos(Users);
            return ListToUserGetDto;
            */
        }

        //{U}
        public bool UpdateUser(Guid userId, UserUpdateDto userUpdateDto)
        {
            foreach (var user in Users)
            {
                if (user.UserId == userId)
                {
                    user.FirstName = userUpdateDto.FirstName;
                    user.LastName = userUpdateDto.LastName;
                    user.NickName = userUpdateDto.NickName;
                    user.ChannelName = userUpdateDto.ChannelName;
                    user.Subscribers = userUpdateDto.Subscribers;
                    user.Durations = userUpdateDto.Durations;
                    return true;
                }
            }

            return false;
        }

        //{D}
        public bool DeleteUser(Guid userId)
        {
            ReadUsersFromFile();
            foreach (var user in Users)
            {
                if (user.UserId == userId   )
                {
                    Users.Remove(user);
                    SaveUserToFile();
                    return true;
                }
            }

            return false;

            /*
            foreach (var user in Users)
            {
                if (user.UserId == userId)
                {
                    Users.Remove(user);
                    return true;
                }
            }

            return false;
            */
        }

        // kanal yoq user
        public UserGetDto? GetUserNonChannel()
        {
            foreach (var user in Users)
            {
                if (user.ChannelName == null)
                {
                    return ToUserGetDto(user);
                }
            }
            return null;
        }

        public UserGetDto? GetUserLikesMaxCount()
        {
            var maxLikesUser = Users[0];
            foreach (var user in Users)
            {
                if (user.LikesNumber > maxLikesUser.LikesNumber)
                {
                    maxLikesUser = user;
                }
            }
            return ToUserGetDto(maxLikesUser);
        }
        public UserGetDto? GetUserDislikesMaxCount()
        {
            var maxDislikesUser = Users[0];
            foreach (var user in Users)
            {
                if (user.DislikesNumber > maxDislikesUser.DislikesNumber)
                {
                    maxDislikesUser = user;
                }
            }
            return ToUserGetDto(maxDislikesUser);
        }
        public UserGetDto? GetUserVideosMaxCount()         // barcha videolari soni
        {
            var maxVideosUser = Users[0];
            foreach (var user in Users)
            {
                if (user.Videos > maxVideosUser.Videos)
                {
                    maxVideosUser = user;
                }
            }
            return ToUserGetDto(maxVideosUser);
        }

        public UserGetDto? GetUserLikesMinCount()
        {
            var minLikesUser = Users[0];
            foreach (var user in Users)
            {
                if (user.LikesNumber < minLikesUser.LikesNumber)
                {
                    minLikesUser = user;
                }
            }
            return ToUserGetDto(minLikesUser);
        }
        public UserGetDto? GetUserDislikesMinCount()
        {
            var minDislikesUser = Users[0];
            foreach (var user in Users)
            {
                if (user.DislikesNumber < minDislikesUser.DislikesNumber)
                {
                    minDislikesUser = user;
                }
            }
            return ToUserGetDto(minDislikesUser);
        }
        public UserGetDto? GetUserVideosMinCount()         // barcha videolari soni
        {
            var minVideosUser = Users[0];
            foreach (var user in Users)
            {
                if (user.Videos < minVideosUser.Videos)
                {
                    minVideosUser = user;
                }
            }
            return ToUserGetDto(minVideosUser);
        }

        public UserGetDto? GetUserSubscribersMaxCount()    // obunachilari max ni
        {
            var maxSubscribersUser = Users[0];
            foreach (var user in Users)
            {
                if (user.Subscribers > maxSubscribersUser.Subscribers)
                {
                    maxSubscribersUser = user;
                }
            }
            return ToUserGetDto(maxSubscribersUser);


        }
        public UserGetDto? GetUserSubscribersMinCount()    // obunachilari min ni
        {
            var minSubscribersUser = Users[0];
            foreach (var user in Users)
            {
                if (user.Subscribers < minSubscribersUser.Subscribers)
                {
                    minSubscribersUser = user;
                }
            }
            return ToUserGetDto(minSubscribersUser);
        }

        public List<UserGetDto> GetTopUsersWithMaxSubscribers(int count)// eng kop obunachilarga ega bo'lganlarin qaytarish (count bn) 
        {
            // Select sort

            for (var i = 0; i < Users.Count(); i++)
            {
                var userWithMaxSubscribers = Users[i];
                var index = i;
                for (var j = i + 1; j < Users.Count(); j++)
                {
                    if (userWithMaxSubscribers.Subscribers < Users[j].Subscribers)
                    {
                        userWithMaxSubscribers = Users[j];
                        index = j;
                    }
                }

                var swapUser = Users[index];
                Users[index] = Users[i];
                Users[i] = swapUser;
            }

            var topUsers = new List<YouTubeUser>();

            for (var i = 0; i < count; i++)
            {
                topUsers.Add(Users[i]);
            }

            return ToUserGetDtos(topUsers);
        }
        public List<UserGetDto> GetTopUsersWithMinSubscribers(int count)// eng kam obunachilarga ega bo'lganlarin qaytarish (count bn) 
        {

            // Select sort

            for (var i = 0; i < Users.Count(); i++)
            {
                var userWithMinSubscribers = Users[i];
                var index = i;
                for (var j = i + 1; j < Users.Count(); j++)
                {
                    if (userWithMinSubscribers.Subscribers > Users[j].Subscribers)
                    {
                        userWithMinSubscribers = Users[j];
                        index = j;
                    }
                }

                var swapUser = Users[index];
                Users[index] = Users[i];
                Users[i] = swapUser;
            }

            var topUsers = new List<YouTubeUser>();

            for (var i = 0; i < count; i++)
            {
                topUsers.Add(Users[i]);
            }

            return ToUserGetDtos(topUsers);
        }


    }

}
