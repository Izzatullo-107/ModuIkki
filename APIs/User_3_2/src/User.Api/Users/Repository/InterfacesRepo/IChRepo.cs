using Microsoft.Extensions.Hosting;
using User.Api.User.Entiti;

namespace User.Api.User.Repository.InterfacesRepo;

public interface IChRepo
{
    public List<UserChannel>? GetAllChannels();
    public void SaveAllChannels(List<UserChannel> channels);
}
