namespace Dars_3_6;

internal class Program
{
    static void Main(string[] args)
    {
        #region delegat3.7

        //M:1
        var sonlar = (int a, int b, int c) =>
        {
            return Math.Max(a, Math.Max(b, c));
        };

        //M:2
        var uzunlik = (string a, string b) => Console.WriteLine(a.Length + b.Length);

        //M:3
        var qimmat = (List<Book> books) =>
        {
            var max = books.MaxBy(b => b.Price);

            return max;
        };

        //M:4 
        var oshgan = (Book book) =>
        {
            Console.WriteLine(book.BookId);
            Console.WriteLine(book.Name);
            Console.WriteLine(book.Price * 10);
        };



        #endregion


        #region delegat3.6
        //Predicate<int> predicate;
        //predicate = s1;
        //predicate += s2;
        //predicate += s3;
        //predicate += s4;

        //var res1 = predicate.Invoke(100);
        //Console.WriteLine(res1);

        //Func<string, string> func;
        //func = Add1;
        //func += Add2;
        //func += Add3;
        //func += Add4;

        //var res2 = func.Invoke("Hello");
        //Console.WriteLine(res2);


        //Action<string,int> action;
        //action = Action1;
        //action += Action2;
        //action += Action3;
        //action += Action4;

        //action.Invoke("Number ", 5);
        #endregion

    }



    #region delegat3.6
    //static bool s1(int input)
    //{
    //   return input > 5;
    //}
    //static bool s2(int input)
    //{
    //   return (input / 2) > 5;
    //}
    //static bool s3(int input)
    //{
    //   return input % 10 != 0;
    //}
    //static bool s4(int input)
    //{
    //    return input < 0;
    //}


    //static string Add1(string input)
    //{
    //    return input + " World";
    //}
    //static string Add2(string input)
    //{
    //    return " C# G13"+ input ;
    //}
    //static string Add3(string input)
    //{
    //    return input.Remove(0,1);
    //}
    //static string Add4(string input)
    //{
    //    return input.Substring(1,5);
    //}

    //static void Action1(string input, int num)
    //{
    //    Console.WriteLine(input + num);
    //}
    // static void Action2(string input, int num)
    //{
    //    Console.WriteLine(input + (num * 2));
    //}
    // static void Action3(string input, int num)
    //{
    //    Console.WriteLine(input.Length + num );
    //}
    // static void Action4(string input, int num)
    //{
    //    Console.WriteLine(input.Substring(0,num));
    //}
    #endregion
}
