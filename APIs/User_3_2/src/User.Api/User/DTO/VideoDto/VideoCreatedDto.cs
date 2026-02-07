namespace User.Api.User.DTO.VideoDto;

public class VideoCreatedDto
{
    public Guid ChannelId { get; set; }
    public Guid UserId { get; set; }
    public string VideoTitle { get; set; }   // video nomi
    public TimeSpan Duration { get; set; }   // video davomiyligi (00:00:00)
}
