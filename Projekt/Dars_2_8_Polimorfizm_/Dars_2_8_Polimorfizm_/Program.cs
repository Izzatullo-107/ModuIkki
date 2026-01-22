using Dars_2_8_Polimorfizm_.Services;

namespace Dars_2_8_Polimorfizm_;

internal class Program
{
    static void Main(string[] args)
    {
        
        EmailService emailService = new EmailService();
        TeamsService teamsService = new TeamsService();
        TgService tgService = new TgService();

        // Send notifications  Yuborish bildirishnomalar
        emailService.SendNotification();
        teamsService.SendNotification();
        tgService.SendNotification();
    }
}
