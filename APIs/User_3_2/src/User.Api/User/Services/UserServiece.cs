using User.Api.User.DTO.UserDto;
using User.Api.User.Entiti;
using User.Api.User.Repository;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Services.Controler;
using User.Api.User.Services.Interfes;

namespace User.Api.User.Services
{
    public class UserService : IUserService
    {
        // readonly vs const
        private readonly IUserRepository UserRepos;
        public UserService()
        {
            UserRepos = new UserRepository();
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
                Position = user.Position

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
        //

        //{C}
        public Guid AddUser(UserCreatedDto user)
        {

            var newUser = new YouTubeUser
            {
                UserId = Guid.NewGuid(),//
                FirstName = user.FirstName,
                LastName = user.LastName,
                NickName = NickNameControl.NickNameUnique(user.NickName),
                CreatedAt = DateTime.UtcNow,//
                UpdatedAt = DateTime.UtcNow,//
                Password = PasswordControl.SavePassword(user.Password, DateTime.UtcNow),
                Position = user.Position

            };
            return UserRepos.Add(newUser);

        }

        //{R}
        public UserGetDto? GetUserById(Guid userId)
        {
            var u = UserRepos.GetById(userId);

            if (u == null) return null;

            return ToUserGetDto(u);
        }

        public List<UserGetDto> GetAllUsers()
        {

            var users = UserRepos.GetAll();

            return ToUserGetDtos(users);
        }

        //{U}
        public bool UpdateUser(Guid userId, UserUpdateDto userUpdateDto)
        {
            var user = UserRepos.GetById(userId);
            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.NickName = userUpdateDto.NickName;
            user.Password = PasswordControl.SavePassword(userUpdateDto.Password, DateTime.UtcNow);
            user.UpdatedAt = DateTime.UtcNow;
            user.CreatedAt = user.CreatedAt;
            user.Position = userUpdateDto.Position;
            UserRepos.Update(userId, user);
            return true;

        }

        //{D}
        public bool DeleteUser(Guid userId)
        {
            if (UserRepos.GetById(userId) == null) return false;

            UserRepos.Delete(userId);
            return true;

        }

        // kanal yoq user
        //public UserGetDto? GetUserNonChannel()
        //{
        //    foreach (var user in Users)
        //    {
        //        if (user.ChannelName == null)
        //        {
        //            return ToUserGetDto(user);
        //        }
        //    }
        //    return null;
        //}

        //public UserGetDto? GetUserLikesMaxCount()
        //{
        //    var maxLikesUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.LikesNumber > maxLikesUser.LikesNumber)
        //        {
        //            maxLikesUser = user;
        //        }
        //    }
        //    return ToUserGetDto(maxLikesUser);
        //}

        //public UserGetDto? GetUserDislikesMaxCount()
        //{
        //    var maxDislikesUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.DislikesNumber > maxDislikesUser.DislikesNumber)
        //        {
        //            maxDislikesUser = user;
        //        }
        //    }
        //    return ToUserGetDto(maxDislikesUser);
        //}

        //public UserGetDto? GetUserVideosMaxCount()         // barcha videolari soni
        //{
        //    var maxVideosUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.Videos > maxVideosUser.Videos)
        //        {
        //            maxVideosUser = user;
        //        }
        //    }
        //    return ToUserGetDto(maxVideosUser);
        //}

        //public UserGetDto? GetUserLikesMinCount()
        //{
        //    var minLikesUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.LikesNumber < minLikesUser.LikesNumber)
        //        {
        //            minLikesUser = user;
        //        }
        //    }
        //    return ToUserGetDto(minLikesUser);
        //}

        //public UserGetDto? GetUserDislikesMinCount()
        //{
        //    var minDislikesUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.DislikesNumber < minDislikesUser.DislikesNumber)
        //        {
        //            minDislikesUser = user;
        //        }
        //    }
        //    return ToUserGetDto(minDislikesUser);
        //}

        //public UserGetDto? GetUserVideosMinCount()         // barcha videolari soni
        //{
        //    var minVideosUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.Videos < minVideosUser.Videos)
        //        {
        //            minVideosUser = user;
        //        }
        //    }
        //    return ToUserGetDto(minVideosUser);
        //}

        //public UserGetDto? GetUserSubscribersMaxCount()    // obunachilari max ni
        //{
        //    var maxSubscribersUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.Subscribers > maxSubscribersUser.Subscribers)
        //        {
        //            maxSubscribersUser = user;
        //        }
        //    }
        //    return ToUserGetDto(maxSubscribersUser);
        //}

        //public UserGetDto? GetUserSubscribersMinCount()    // obunachilari min ni
        //{
        //    var minSubscribersUser = Users[0];
        //    foreach (var user in Users)
        //    {
        //        if (user.Subscribers < minSubscribersUser.Subscribers)
        //        {
        //            minSubscribersUser = user;
        //        }
        //    }
        //    return ToUserGetDto(minSubscribersUser);
        //}

        //public List<UserGetDto> GetTopUsersWithMaxSubscribers(int count)// eng kop obunachilarga ega bo'lganlarin qaytarish (count bn) 
        //{
        //    // Select sort

        //    for (var i = 0; i < Users.Count(); i++)
        //    {
        //        var userWithMaxSubscribers = Users[i];
        //        var index = i;
        //        for (var j = i + 1; j < Users.Count(); j++)
        //        {
        //            if (userWithMaxSubscribers.Subscribers < Users[j].Subscribers)
        //            {
        //                userWithMaxSubscribers = Users[j];
        //                index = j;
        //            }
        //        }

        //        var swapUser = Users[index];
        //        Users[index] = Users[i];
        //        Users[i] = swapUser;
        //    }

        //    var topUsers = new List<YouTubeUser>();

        //    for (var i = 0; i < count; i++)
        //    {
        //        topUsers.Add(Users[i]);
        //    }

        //    return ToUserGetDtos(topUsers);
        //}

        //public List<UserGetDto> GetTopUsersWithMinSubscribers(int count)// eng kam obunachilarga ega bo'lganlarin qaytarish (count bn) 
        //{

        //    // Select sort

        //    for (var i = 0; i < Users.Count(); i++)
        //    {
        //        var userWithMinSubscribers = Users[i];
        //        var index = i;
        //        for (var j = i + 1; j < Users.Count(); j++)
        //        {
        //            if (userWithMinSubscribers.Subscribers > Users[j].Subscribers)
        //            {
        //                userWithMinSubscribers = Users[j];
        //                index = j;
        //            }
        //        }

        //        var swapUser = Users[index];
        //        Users[index] = Users[i];
        //        Users[i] = swapUser;
        //    }

        //    var topUsers = new List<YouTubeUser>();

        //    for (var i = 0; i < count; i++)
        //    {
        //        topUsers.Add(Users[i]);
        //    }

        //    return ToUserGetDtos(topUsers);
        //}


    }

}
