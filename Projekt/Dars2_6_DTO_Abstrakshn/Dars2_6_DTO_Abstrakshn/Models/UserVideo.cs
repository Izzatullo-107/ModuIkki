using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_6_DTO_Abstrakshn.Models;

public class UserVideo
{
    public Guid VideoId { get; set; }
    public string VideoTitle { get; set; }   // video nomi
    public int Duration { get; set; }        // video davomiyligi
    public int? LikesNumber { get; set; }    
    public int? DislikesNumber { get; set; } 
    public DateTime CreatedDate { get; set; }
}
