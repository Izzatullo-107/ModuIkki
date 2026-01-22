using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_7_Accsecc_mode_fayllar;

public class User
{
    public Guid UserId { get; set; }
    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    private string userName;
    private string email;
    private string password;
    private string fullName;


}
