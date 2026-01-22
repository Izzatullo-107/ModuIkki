using Dars2_5_Abstarakshin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_5_Abstarakshin.Services.Interfaces;

public interface ICountryService
{
    public Guid AddCountry(Country country);
    public bool UpdateCountry(Country country);
    public bool DeleteCountry(Guid countryId);
    public Country? GetCountryById(Guid countryId);
    public List<Country> GetAllCountries();

}
