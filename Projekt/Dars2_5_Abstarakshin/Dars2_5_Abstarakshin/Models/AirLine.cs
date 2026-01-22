using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Models;

public class AirLine
{
    public Guid AirLineId { get; set; }
    public string Name { get; set; }
    public double Area { get; set; }
    public int Rating { get; set; }
    public int WorkersNumber { get; set; }
}
