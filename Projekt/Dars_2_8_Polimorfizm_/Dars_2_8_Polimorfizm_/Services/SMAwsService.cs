using Dars_2_8_Polimorfizm_.Models;
using Dars_2_8_Polimorfizm_.Services.Interfess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_8_Polimorfizm_.Services;

public class SMAwsService : ISocialMediaService
{
    // US Aws Ielts UK RU AI
    List<SocialMedia> SocialMediasAws = new List<SocialMedia>();
    //{C}
    public Guid Add(SocialMedia socialMedia)
    {
        socialMedia.SocialMediaId = Guid.NewGuid();
        SocialMediasAws.Add(socialMedia);
        return socialMedia.SocialMediaId;
    }

    //{D}
    public bool Delete(Guid id)
    {
        foreach (var sM in SocialMediasAws)
        {
            if (sM.SocialMediaId == id)
            {
                SocialMediasAws.Remove(sM);
                return true;
            }
        }
        return false;
    }

    //{R}
    public List<SocialMedia> GetAll()
    {
        return SocialMediasAws;
    }

    public SocialMedia? GetById(Guid id)
    {
        foreach (var sM in SocialMediasAws)
        {
            if (sM.SocialMediaId == id)
            {
                return sM;
            }
        }

        return null;
    }

    //{U}
    public bool Update(Guid id, SocialMedia socialMedia)
    {
        foreach (var sM in SocialMediasAws)
        {
            if (sM.SocialMediaId == id)
            {
                sM.Name = socialMedia.Name;
                sM.Description = socialMedia.Description;
                sM.Ceo = socialMedia.Ceo;
                return true;
            }
        }

        return false;
    }

    //{SMS}
    public void SendNotifications()
    {
        //EmailService emailService = new EmailService();
        //emailService.SendNotification();

        //TeamsService teamsService = new TeamsService(); 
        //teamsService.SendNotification();

        TgService tgService = new TgService();
        tgService.SendNotification();

        Console.WriteLine("Hamma xodimlarga AWS dan notification ketdi");
    }


}