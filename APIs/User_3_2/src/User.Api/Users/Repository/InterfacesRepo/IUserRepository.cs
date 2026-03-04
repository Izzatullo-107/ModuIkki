using User.Api.User.Entiti;

namespace User.Api.User.Repository.Interfaces
{
    public interface IUserRepository
    {
        public List<YouTubeUser>? GetAllUsers();
        public void SaveAllUsers(List<YouTubeUser> users);
        public bool? UserBlocked(Guid userId);
        public bool UserExists(Guid userId);
    }
}
