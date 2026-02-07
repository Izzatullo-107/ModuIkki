namespace User.Api.User.Entiti
{
    public class UserVideo
    {
        public Guid VideoId { get; set; }
        public Guid ChannelId { get; set; }        
        public Guid UserId { get; set; }         
        public string VideoTitle { get; set; }   // video nomi
        public TimeSpan Duration { get; set; }   // video davomiyligi (00:00:00)
        public int? LikesNumber { get; set; }
        public int? DislikesNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
