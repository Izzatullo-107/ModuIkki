using User.Api.Users.Entiti;

namespace User.Api.Users.Repository.InterfacesRepo;

public interface ICommentRepo
{
    public List<Comment>? GetAllComments();
    public void SaveAllComments(List<Comment> comments);
}
