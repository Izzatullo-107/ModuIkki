using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_10_Entensions.IntEntensions;

public static class stringExtension
{
    public static int GetCountOfCat(this string str)
    {
        int count = 0;
        for (int i = 0; i < str.Length - 2; i++) // catghgcat
        {
            if (str.Substring(i, 3).ToLower() == "cat")
            {
                count++;
            }
        }
        return count;
    }
}
