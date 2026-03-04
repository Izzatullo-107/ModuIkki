namespace User.Api.Users.Entiti;

public class Comment
{
    public Guid CommentId { get; set; }
    public string Content { get; set; }
    public Guid VideoId { get; set; }
    public Guid? ReplyId { get; set; }
    public Guid UserId { get; set; }
    public int? LikesCount { get; set; }
    public int? DislikesCount { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
