using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars_2_10_Entensions.IntEntensions;

public static class stringExtensionTouple
{
    public static (char bir, char oxir, int uzun, string boshUch, string oxirUch)  All(this string text)
    {
        var bir = text[0];
        var oxir= text[text.Length-1];

        var uzun = text.Length;
        var oxirUch = text.Substring(text.Length-3);
        var boshUch = text.Substring(0,3);

        return( bir, oxir,uzun, boshUch,oxirUch);
    }
}
