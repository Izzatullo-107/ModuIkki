
namespace User.Api.User.Services.Controler;

public static class PasswordControl
{
    static PasswordControl() { }

    public static string SavePassword(string password, DateTime now)
    {
        var hashed = string.Empty;
        

        //bu stringdagi barchasi son va 4 xonali ekanlligni tekshiradi
        //if (password.Length != 4 || !password.All(char.IsDigit))
        //{
        //    return false;
        //}
       
        switch (now.Hour)
        {
            case >= 0 and <= 6 :
                hashed = SavePasswordPrivateHash(now.Hour + password, 1);
                break;
            case >= 7 and <= 14:
                hashed = now.Hour + SavePasswordPrivateHash(password, 2);
                break;
            case >= 15 and <= 23:
                hashed = now.Hour + SavePasswordPrivateHash(password, 3);
                break;

        }

        return hashed;
    }

    public static bool TestPassword(string savedPassword, string inputPassword, DateTime now)
    {
        string hashedInputPassword = string.Empty;
        switch (now.Hour)
        {
            case >= 0 and <= 6:
                hashedInputPassword = SavePasswordPrivateHash(now.Hour + inputPassword, 1);
                break;
            case >= 7 and <= 14:
                hashedInputPassword = SavePasswordPrivateHash(now.Hour + inputPassword, 2);
                break;
            case >= 15 and <= 23:
                hashedInputPassword =  SavePasswordPrivateHash(now.Hour + inputPassword, 3);
                break;
        }
        return savedPassword == hashedInputPassword;
    }

    private static string SavePasswordPrivateHash(string text,int son)
    {
        var hashed = string.Empty;
        switch (son)
        {
            case 1:
                foreach (var i in text)
                {
                 if(i=='0')
                        hashed += "+.+";
                 if(i=='1')
                        hashed += "=+.";
                 if(i=='2')
                        hashed += ".._";
                 if(i=='3')
                        hashed += ".-=";
                 if(i=='4')
                        hashed += ".**";
                 if(i=='5')
                        hashed += "-..";
                 if(i=='6')
                        hashed += ".*-";
                 if(i=='7')
                        hashed += ".-_";
                 if(i=='8')
                        hashed += "+.-";
                 if(i=='9')
                        hashed += "--.";
                }
                break;

            case 2:
                foreach (var i in text)
                {
                    if (i == '0')
                        hashed += "=+=";
                    if (i == '1')
                        hashed += "_..";
                    if (i == '2')
                        hashed += ".=.";
                    if (i == '3')
                        hashed += "..-";
                    if (i == '4')
                        hashed += "._.";
                    if (i == '5')
                        hashed += "-.-";
                    if (i == '6')
                        hashed += "-_.";
                    if (i == '7')
                        hashed += "+-+";
                    if (i == '8')
                        hashed += "___";
                    if (i == '9')
                        hashed += "---";
                }
                break;

            case 3:
                foreach (var i in text)
                {
                    if (i == '0')
                        hashed += "_._";
                    if (i == '1')
                        hashed += "+.=";
                    if (i == '2')
                        hashed += "...";
                    if (i == '3')
                        hashed += "..*";
                    if (i == '4')
                        hashed += ".=-";
                    if (i == '5')
                        hashed += "-.=";
                    if (i == '6')
                        hashed += "-+-";
                    if (i == '7')
                        hashed += ".-.";
                    if (i == '8')
                        hashed += "=.=";
                    if (i == '9')
                        hashed += "=_=";
                }
                break;
        }

        return hashed;
    }

}
