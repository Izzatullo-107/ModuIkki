namespace User.Api.User.DTO
{
    public class UserCreatedDto
    {
        public string LastName { get; set; }  // familiya
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string ChannelName { get; set; }    // kanal nomi
        public int Subscribers { get; set; }       // obunachilar soni

        //
        public int Durations { get; set; }        // video davomiyligi
    }
}
