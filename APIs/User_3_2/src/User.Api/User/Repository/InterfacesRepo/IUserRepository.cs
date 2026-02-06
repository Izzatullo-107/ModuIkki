using User.Api.User.Entiti;

namespace User.Api.User.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Guid Add(YouTubeUser user);
        public List<YouTubeUser> GetAll();
        public YouTubeUser? GetById(Guid id);
        public bool Delete(Guid id);
        public bool Update(Guid id, YouTubeUser user);


    }
}
