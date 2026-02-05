using Dars_2_8_Polimorfizm_.Services;
using Dars_2_8_Polimorfizm_.Services.Interfess;

namespace Dars_2_8_Polimorfizm_;

internal class Program
{
    static void Main(string[] args)
    {
        

















    }

    public static ISocialMediaService GetSocialMediaService()
    {
        //ISocialMediaService socialMediaService = new SMAwsService();
        ISocialMediaService socialMediaService = new SMAzureService();
        return socialMediaService;
    }

    public static ISendNotifications SendNotifications()
    {
        //ISendNotifications emailService = new EmailService();
        //ISendNotifications emailService = new TeamsService();
        ISendNotifications emailService = new TgService();

        return emailService;
    }
}
