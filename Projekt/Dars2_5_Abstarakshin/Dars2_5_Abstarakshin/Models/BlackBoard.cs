using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Models;

public class BlackBoard
{
    public Guid BlackBoardId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public double Width { get; set; }// eni
    public double Height { get; set; } // balandligi
    public double Length { get; set; } // uzunligi
    public override string ToString()
    {
        return $"Name: {Name}\nColor: {Color}\nWidth: {Width}\nHeight: {Height}\nLength: {Length}\n";
    }
}
