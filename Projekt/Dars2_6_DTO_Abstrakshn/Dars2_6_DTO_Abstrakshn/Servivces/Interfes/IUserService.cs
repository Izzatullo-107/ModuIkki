using Dars2_6_DTO_Abstrakshn.DTOs;
using Dars2_6_DTO_Abstrakshn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_6_DTO_Abstrakshn.Servivces.Interfes;

public interface IUserService
{
    public Guid AddUser(UserCreatedDto user);
    public UserGetDto? GetUserById(Guid userId);// bitta userni id  boyicha olish
    public List<UserGetDto> GetAllUsers();
    public bool DeleteUser(Guid userId);
    public bool UpdateUser(Guid userId,UserUpdateDto userUpdateDto);
    public UserGetDto? GetUserNonChannel();      // kanal yoq user    
    public UserGetDto? GetUserLikesMaxCount();      // max ni
    public UserGetDto? GetUserLikesMinCount();      // min ni
    public UserGetDto? GetUserDislikesMaxCount();   // max ni
    public UserGetDto? GetUserDislikesMinCount();   // min ni
    public UserGetDto? GetUserVideosMaxCount();     //  videolari max ni
    public UserGetDto? GetUserVideosMinCount();     //  videolari min ni
    public UserGetDto? GetUserSubscribersMaxCount();// obunachilari max ni
    public UserGetDto? GetUserSubscribersMinCount();// obunachilari min ni
    public List<UserGetDto> GetTopUsersWithMaxSubscribers(int count);// eng kop obunachilarga ega bo'lganlarin qaytarish (count bn) 
    public List<UserGetDto> GetTopUsersWithMinSubscribers(int count);// eng kam obunachilarga ega bo'lganlarin qaytarish (count bn) 
}
