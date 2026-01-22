using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_6_DTO_Abstrakshn.Models;

public class UserChannel
{
    public Guid ChannelId { get; set; }
    public string ChannelName { get; set; }    // kanal nomi
    public string Description { get; set; }    // video davomiyligi
    public DateTime CreatedDate { get; set; }
    public int Subscribers { get; set; }       // obunachilar soni
    public List<UserVideo> Videos { get; set; }

}
