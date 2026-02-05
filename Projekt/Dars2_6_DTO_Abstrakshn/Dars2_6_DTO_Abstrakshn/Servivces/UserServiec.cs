using Dars2_6_DTO_Abstrakshn.DTOs;
using Dars2_6_DTO_Abstrakshn.Models;
using Dars2_6_DTO_Abstrakshn.Servivces.Interfes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_6_DTO_Abstrakshn.Servivces;


public  class UserServiec:IUserService

{
    List<YouTubeUser> Users; 
   
    public UserServiec()
    {
        Users=new List<YouTubeUser>();
    }
    //
    // ---------------------------------------
    # region ToUserGetDto/s
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
    #endregion ////////////////////////////////////////////////////////////////////////////////////// 
    // ---------------------------------------
    //

    //{C}
    public Guid AddUser(UserCreatedDto user)
    {
        var newUser= new YouTubeUser
        {
            UserId = Guid.NewGuid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            NickName = user.NickName,
            Password = user.Password,
            ChannelName = user.ChannelName,
            Subscribers= user.Subscribers,
            Durations= user.Durations,
            LikesNumber=0,
            DislikesNumber=0
        };
        Users.Add(newUser);
        return newUser.UserId;

    }

    //{R}
    public UserGetDto? GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }
    public List<UserGetDto> GetAllUsers()
    {
        var ListToUserGetDto = ToUserGetDtos(Users);
        return ListToUserGetDto;
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
        foreach (var user in Users)
        {
            if (user.UserId == userId)
            {
                Users.Remove(user);
                return true;
            }
        }

        return false;
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
            if(user.Subscribers > maxSubscribersUser.Subscribers)
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
