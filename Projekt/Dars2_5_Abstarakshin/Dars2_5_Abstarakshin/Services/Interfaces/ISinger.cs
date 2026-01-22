using Dars2_5_Abstarakshin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Services.Interfaces;

internal interface ISinger
{
    public Guid AddSinger(Singer singer);
    public bool DeleteSinger(Guid singerId);
    public bool UpdateSinger(Guid singerId, Singer singer);
    public Singer? GetSingerById(Guid singerId);
    public List<Singer> GetAllSingers();

}
