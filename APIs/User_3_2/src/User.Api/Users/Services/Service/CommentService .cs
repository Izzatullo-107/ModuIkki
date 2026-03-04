using User.Api.Users.Repository.InterfacesRepo;
using User.Api.User.Repository.InterfacesRepo;
using User.Api.Users.Repository.ServicesRepo;
using User.Api.User.Repository.ServicesRepo;
using User.Api.User.Repository.Interfaces;
using User.Api.Users.Services.Interfes;
using User.Api.Users.DTO.CommentDto;
using User.Api.Users.Entiti;

namespace User.Api.Users.Services.Service;

public class CommentService : ICommentService
{
    private readonly IVideoRepo VideoRepository;
    private readonly ITokenService TokenService;
    private readonly IUserRepository UserRepository;
    private readonly ICommentRepo CommentRepository;

    public CommentService()
    {
        VideoRepository = new VideoRepo();
        TokenService = new TokenService();
        UserRepository = new UserRepository();
        CommentRepository = new CommentRepo();
    }

    public Guid Add(CommentCreateDto commentCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(tokenResult.userId);

        if (userBlocked == true)
        {
            return Guid.Empty;
        }

        var userExists = UserRepository.UserExists(tokenResult.userId);

        if (!userExists)
        {
            return Guid.Empty;
        }

        var now = DateTime.UtcNow;

        var comment = new Comment
        {              //commentCreateDto.ToEntity();
            Content = commentCreateDto.Content,
            VideoId = commentCreateDto.PostId,
            ReplyId = commentCreateDto.ReplyId,
            CommentId = Guid.NewGuid(),
            CreateAt = now,
            UpdateAt = now,
            UserId = tokenResult.userId,
            LikesCount = 0,
            DislikesCount = 0
        };

        var comments = CommentRepository.GetAllComments();
        comments.Add(comment);
        CommentRepository.SaveAllComments(comments);
        return comment.CommentId;
    }

    public bool Delete(Guid id, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userRole = tokenResult.role;
        var isAdmin = userRole == "Admin" || userRole == "SuperAdmin";


        var comments = CommentRepository.GetAllComments();

        foreach (var c in comments)
        {
            if (c.CommentId == id && c.UserId == tokenResult.userId || isAdmin && c.CommentId == id)
            {
                comments.Remove(c);
                CommentRepository.SaveAllComments(comments);
                return true;
            }
        }

        return false;
    }

    public List<CommentGetDto> GetAll(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userRole = tokenResult.role;

        var comments = CommentRepository.GetAllComments();

        if (userRole == "Admin" || userRole == "SuperAdmin")
        {
            return comments.Select(c => new CommentGetDto
            {
                CommentId = c.CommentId,
                ReplyId = c.ReplyId,
                UserId = c.UserId,
                PostId = c.VideoId,
                Content = c.Content,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt,
                LikesCount = c.LikesCount,
                DislikesCount = c.DislikesCount
            }).ToList();
        }

        return comments
            .Where(c => c.UserId == tokenResult.userId)
            .Select(c => new CommentGetDto
            {
                CommentId = c.CommentId,
                ReplyId = c.ReplyId,
                UserId = c.UserId,
                PostId = c.VideoId,
                Content = c.Content,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt,
                LikesCount = c.LikesCount,
                DislikesCount = c.DislikesCount
            }).ToList();
    }

    public List<CommentGetDto> GetCommentsByPostId(Guid postId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userRole = tokenResult.role;

        var videos = VideoRepository.GetAllVideos();

        var video = videos.FirstOrDefault(p => p.UserId == tokenResult.userId);

        if (video == null)
        {
            return new List<CommentGetDto>();
        }

        var comments = CommentRepository.GetAllComments();
        return comments
            .Where(c => c.VideoId == video.VideoId)
            .Select(c => new CommentGetDto
            {
                CommentId = c.CommentId,
                ReplyId = c.ReplyId,
                UserId = c.UserId,
                PostId = c.VideoId,
                Content = c.Content,
                CreateAt = c.CreateAt,
                UpdateAt = c.UpdateAt,
                LikesCount = c.LikesCount,
                DislikesCount = c.DislikesCount
            }).ToList();
    }

    public List<CommentGetDto> GetReplyComments(Guid commentId, string token)
    {
        throw new NotImplementedException();
    }

    public bool Update(Guid commentId, CommentUpdateDto commentUpdateDto, string token)
    {
        throw new NotImplementedException();
    }
}
