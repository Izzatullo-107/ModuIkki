using System.Text.Json;
using User.Api.User.Entiti;
using User.Api.User.Repository;
using User.Api.User.Repository.Interfaces;
using User.Api.User.Repository.ServicesRepo;

namespace User.Api.User.Services.Controler;

public static class NickNameControl
{
    private static IUserRepository UserRepos;
    static NickNameControl()
    {
        UserRepos=new UserRepository();
    }

    public static string NickNameUnique(string nickName)
    {
        var users = UserRepos.GetAll();
        var newNickNames = string.Empty;
        //nickNames = Users.Select(u => u.NickName).ToList();
        foreach (var user in users)
        {
            if(user.NickName==nickName)
            {
                newNickNames = nickName +'_';
                break;
            }
        }

        foreach (var user in users)
        {
            if(user.NickName== newNickNames)
            {
                newNickNames = nickName + users.Count.ToString();
                break;
            }
        }
        return newNickNames;
    }
}
