using Dars2_5_Abstarakshin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Services.Interfaces;

internal interface IAirLine
{
    public Guid AddAirLine(AirLine airLine);
    public bool UpdateAirLine(AirLine airLine);
    public bool DeleteAirLine(Guid airLineId);
    public AirLine? GetAirLineById(Guid airLineId);
    public List<AirLine> GetAllAirLines();
}
