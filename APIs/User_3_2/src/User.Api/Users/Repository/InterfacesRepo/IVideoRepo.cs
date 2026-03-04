using Microsoft.Extensions.Hosting;
using User.Api.User.DTO.UserDto;
using User.Api.User.DTO.VideoDto;
using User.Api.User.Entiti;

namespace User.Api.User.Repository.InterfacesRepo;

public interface IVideoRepo
{
    public List<UserVideo>? GetAllVideos();
    public void SaveAllVideos(List<UserVideo> videos);
}
