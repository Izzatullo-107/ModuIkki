namespace User.Api.Users.DTO.CommentDto;

public class CommentCreateDto
{
    public string Content { get; set; }
    public Guid PostId { get; set; }
    public Guid? ReplyId { get; set; }
}
