namespace User.Api.User.Entiti
{
    public class UserChannel
    {
        public Guid ChannelId { get; set; }
        public string ChannelName { get; set; }    // kanal nomi
        public string Description { get; set; }    // video davomiyligi
        public DateTime CreatedDate { get; set; }
        public int Subscribers { get; set; }       // obunachilar soni
        public List<UserVideo> Videos { get; set; }

    }

}
