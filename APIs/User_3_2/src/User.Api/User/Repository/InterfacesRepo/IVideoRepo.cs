using User.Api.User.DTO.UserDto;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Entiti;

namespace User.Api.User.Repository.InterfacesRepo;

public interface IVideoRepo
{
    public Guid Add(UserVideo video);
    public UserVideo? GetById(Guid videoId);// bitta userni id  boyicha olish
    public List<UserVideo> GetAll();
    public bool Update(Guid videoId, UserVideo videoUpdateDto);
    public bool Delete(Guid videoId);
}
