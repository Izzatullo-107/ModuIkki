using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_10_Entensions.IntEntensions;

public static class intExtension
{
    public static int GetSumOfFromOne(this int number)
    {
        int sum = 0;
        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }
        return sum;
    }
}
