using Dars2_5_Abstarakshin.Models;
using Dars2_5_Abstarakshin.Services.Interfaces;

namespace Dars2_5_Abstarakshin.Services;

internal class SingerService : ISinger
{
    private readonly List<Singer> Singers;
    public SingerService()
    {
        Singers = new List<Singer>();
    }

    //{C}
    public Guid AddSinger(Singer singer)
    {
        singer.SingerId = Guid.NewGuid();
        Singers.Add(singer);
        return singer.SingerId;
    }

    //{R}
    public Singer? GetSingerById(Guid singerId)
    {
        return Singers.FirstOrDefault(s => s.SingerId == singerId);
    }
    public List<Singer> GetAllSingers()
    {
        return Singers;
    }

    //{U}
    public bool UpdateSinger(Guid singerId, Singer singer)
    {
        var existingSinger = Singers.FirstOrDefault(s => s.SingerId == singerId);
        if (existingSinger != null)
        {
            existingSinger.LastName = singer.LastName;
            existingSinger.FirstName = singer.FirstName;
            existingSinger.BirthDate = singer.BirthDate;
            existingSinger.Genre = singer.Genre;
            existingSinger.Price = singer.Price;

            return true;
        }
        return false;
    }

    //{D}
    public bool DeleteSinger(Guid singerId)
    {
        var singer = Singers.FirstOrDefault(s => s.SingerId == singerId);
        if (singer == null) return false;
        Singers.Remove(singer);
        return true;
    }
   
    
    
}
