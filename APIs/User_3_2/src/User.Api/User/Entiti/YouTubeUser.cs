namespace User.Api.User.Entiti
{
    public class YouTubeUser
    {
        public Guid UserId { get; set; }            // id raqami
        public string LastName { get; set; }        // familiya
        public string FirstName { get; set; }       // ism
        public string NickName { get; set; }        // tarmoqdagi nomi
        public string Password { get; set; }        // paroli
        public string Position { get; set; }         // lavozmi
        public DateTime CreatedAt { get; set; }      // yaratildi vaqti
        public DateTime UpdatedAt { get; set; }      // yangilandi vaqti

        //public string ChannelName { get; set; }     // kanal nomi
        //public int Subscribers { get; set; }        // obunachilar soni
        //public int Durations { get; set; }          // video davomiyligi
        //public int? LikesNumber { get; set; }       // yoqtirishlar soni
        //public int? DislikesNumber { get; set; }    // yoqtirmasliklar soni
        //public int? Videos { get; internal set; }   // videolar soni
    }

}
