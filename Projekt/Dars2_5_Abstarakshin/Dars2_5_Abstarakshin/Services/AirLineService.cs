using Dars2_5_Abstarakshin.Models;
using Dars2_5_Abstarakshin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Services;

internal class AirLineService : IAirLine
{
    List<AirLine> AirLines;
    public AirLineService()
    {
        AirLines = new List<AirLine>();
    }

    //{C}
    public Guid AddAirLine(AirLine airLine)
    {
        airLine.AirLineId = Guid.NewGuid();
        AirLines.Add(airLine);
        return airLine.AirLineId;
    }

    //{R}
    public AirLine? GetAirLineById(Guid airLineId)
    {
        return AirLines.FirstOrDefault(c => c.AirLineId == airLineId);
    }
    public List<AirLine> GetAllAirLines()
    {
        return AirLines;
    }

    //{U}
    public bool UpdateAirLine(AirLine airLine)
    {
        /*
        var updateAirLine = AirLines.FirstOrDefault(c => c.AirLineId == airLine.AirLineId);
        if (updateAirLine != null)
        {
            updateAirLine.Name = airLine.Name;
            updateAirLine.Rating = airLine.Rating;
            updateAirLine.Area = airLine.Area;
            updateAirLine.WorkersNumber = airLine.WorkersNumber;
            return true;
        }
        return false;
        */

        foreach (var airLinee in AirLines)
        {
            if (airLinee.AirLineId == airLine.AirLineId)
            {
                airLinee.Name = airLine.Name;
                airLinee.Rating = airLine.Rating;
                airLinee.Area = airLine.Area;   
                airLinee.WorkersNumber = airLine.WorkersNumber;
            }
            return true;
        }
        return false;
         
    }


    //{D}
    public bool DeleteAirLine(Guid airLineId)
    {
        var airLine = AirLines.FirstOrDefault(c => c.AirLineId == airLineId);
        if (airLine != null)
        {
            AirLines.Remove(airLine);
            return true;
        }
        return false;
    }
    
}
