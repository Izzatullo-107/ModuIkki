using User.Api.Users.DTO.CommentDto;

namespace User.Api.Users.Services.Interfes;

public interface ICommentService
{
    public Guid Add(CommentCreateDto commentCreateDto, string token);
    public bool Delete(Guid id, string token);
    public List<CommentGetDto> GetAll(string token);
    public bool Update(Guid commentId, CommentUpdateDto commentUpdateDto, string token);
    public List<CommentGetDto> GetCommentsByPostId(Guid postId, string token);
    public List<CommentGetDto> GetReplyComments(Guid commentId, string token);
}
