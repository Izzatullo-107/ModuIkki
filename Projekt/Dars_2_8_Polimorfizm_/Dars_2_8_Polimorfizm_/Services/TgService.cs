using Dars_2_8_Polimorfizm_.Services.Interfess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_8_Polimorfizm_.Services;

public class TgService: ISendNotifications
{
    public void SendNotification()
    {
        Console.WriteLine("Hamma xodimlarga Tgdan notification ketdi");
    }
}
