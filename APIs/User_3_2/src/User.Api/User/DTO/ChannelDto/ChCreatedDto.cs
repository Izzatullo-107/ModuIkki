namespace User.Api.User.DTO.ChannelDto;

public class ChCreatedDto
{
    public Guid UserId { get; set; }
    public string ChannelName { get; set; }    // kanal nomi
    public string Description { get; set; }    // kanal tavsifi
    public string Category { get; set; }       // kanal turi
}
