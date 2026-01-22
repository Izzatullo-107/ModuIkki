using Dars2_5_Abstarakshin.Models;
using Dars2_5_Abstarakshin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Services;

public class CountryService : ICountryService
{
    private List<Country> Countries ;

    public CountryService()
    {
        Countries  = new List<Country>();
    }

    //{C}
    public Guid AddCountry(Country country)
    {
        country.CountryId = Guid.NewGuid();
        Countries.Add(country);
        return country.CountryId;
    }

    //{R}
    public Country? GetCountryById(Guid countryId)
    {
        return Countries.FirstOrDefault(c => c.CountryId == countryId);
    }

    public List<Country> GetAllCountries()
    {
        return Countries;
    }

    //{U}
    public bool UpdateCountry( Country country)
    {
        var existingCountry = Countries.FirstOrDefault(c => c.CountryId == country.CountryId);
        if (existingCountry != null)
        {
            existingCountry.Name = country.Name;
            existingCountry.Area = country.Area;
            existingCountry.IpAddress = country.IpAddress;
            existingCountry.Population = country.Population;
            return true;
        }
        return false;


    }

    //{D}
    public bool DeleteCountry(Guid countryId)
    {
        var country = Countries.FirstOrDefault(c => c.CountryId == countryId);
        if (country != null)
        {
            Countries.Remove(country);
            return true;
        }
        return false;
    }

    
}
