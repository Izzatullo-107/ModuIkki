using User.Api.User.Entiti;

namespace User.Api.User.Repository.InterfacesRepo;

public interface IChRepo
{
    public Guid Add(UserChannel user);
    public List<UserChannel> GetAll();
    public UserChannel? GetById(Guid id);
    public bool Delete(Guid id);
    public bool Update(Guid id, UserChannel user);
}
