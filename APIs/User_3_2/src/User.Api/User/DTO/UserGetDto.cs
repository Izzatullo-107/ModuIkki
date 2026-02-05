namespace User.Api.User.DTO
{
    public class UserGetDto
    {
        public Guid UserId { get; set; }
        public string LastName { get; set; }  // familiya
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string ChannelName { get; set; }    // kanal nomi
        public int Subscribers { get; set; }       // obunachilar soni

        //
        public int Durations { get; set; }        // video davomiyligi
        public int? LikesNumber { get; set; }
        public int? DislikesNumber { get; set; }
    }
}
