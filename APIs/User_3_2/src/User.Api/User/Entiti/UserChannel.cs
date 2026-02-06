namespace User.Api.User.Entiti
{
    public class UserChannel
    {
        public Guid ChannelId { get; set; }
        public Guid UserId { get; set; }          //  user id'
        public string ChannelName { get; set; }    // kanal nomi
        public string Description { get; set; }    // kanal tavsifi
        public string Category { get; set; }       // kanal turi
        public int Subscribers { get; set; }       // obunachilar soni
        public DateTime CreatedDate { get; set; }  
        public DateTime UpdatedDate { get; set; }  
      

    }

}
