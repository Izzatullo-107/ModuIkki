namespace User.Api.User.DTO.ChannelDto;

public class ChGetDto
{
    public Guid ChannelId { get; set; }
    public Guid UserId { get; set; }
    public string ChannelName { get; set; }    // kanal nomi
    public string Description { get; set; }    // kanal tavsifi
    public string Category { get; set; }       // kanal turi
    public int Subscribers { get; set; }       // obunachilar soni
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
