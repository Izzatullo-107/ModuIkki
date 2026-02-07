using System.Text.Json;
using User.Api.User.Entiti;
using User.Api.User.Repository;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.ServicesRepo;

namespace User.Api.User.Services.Controler;

public static class NickNameControl
{
    private static readonly IUserRepository UserRepos;
    static NickNameControl()
    {
        UserRepos=new UserRepository();
    }

    public static string NickNameUnique(string nickName)
    {
        var users = UserRepos.GetAll();
        var newNickNames = string.Empty;
        if (nickName == null)
        {
            newNickNames = "youtubeUser" + users.Count.ToString();
            return newNickNames;
        }
        //nickNames = Users.Select(u => u.NickName).ToList();
        foreach (var user in users)
        {
            if(user.NickName==nickName)
            {
                newNickNames = nickName +'_';
                break;
            }
        }

        if (newNickNames == null)
        {
            newNickNames = nickName;
            return newNickNames;
        }

        foreach (var user in users)
        {
            if(user.NickName == newNickNames)
            {
                newNickNames = nickName + users.Count.ToString();
                break;
            }
        }

        if (newNickNames == null)
            newNickNames = nickName;

        return newNickNames;
    }
}
