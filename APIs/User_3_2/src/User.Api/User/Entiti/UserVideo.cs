namespace User.Api.User.Entiti
{
    public class UserVideo
    {
        public Guid VideoId { get; set; }
        public string VideoTitle { get; set; }   // video nomi
        public int Duration { get; set; }        // video davomiyligi
        public int? LikesNumber { get; set; }
        public int? DislikesNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
