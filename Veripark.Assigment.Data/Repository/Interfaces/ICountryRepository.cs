using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veripark.Assigment.Data.Models;

namespace Veripark.Assigment.Data.Repository.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> AllCountries { get; }
        Country GetCountryById(int countryId);
    }
}
