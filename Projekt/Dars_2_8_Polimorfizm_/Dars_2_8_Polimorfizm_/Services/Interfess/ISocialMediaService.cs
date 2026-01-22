using Dars_2_8_Polimorfizm_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_8_Polimorfizm_.Services.Interfess;

public interface ISocialMediaService
{
    public Guid Add(SocialMedia socialMedia);
    public List<SocialMedia> GetAll();
    public SocialMedia? GetById(Guid id);
    public bool Update(Guid id, SocialMedia socialMedia);
    public bool Delete(Guid id);
    public void SendNotifications();
}
