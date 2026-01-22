namespace Dars_2_7_Accsecc_mode_fayllar
{
    internal class Program
    {
        static void Main(string[] args)
        {
           User user = new User();
            user.UserName = "john_doe";
            user.Email = "john@example.com";
            user.Password = "securepassword";
            user.FullName = "John Doe";
            Console.WriteLine(user.UserName);
            Console.WriteLine(user.Email);
            Console.WriteLine(user.Password);
            Console.WriteLine(user.FullName);
        }
    }
}
