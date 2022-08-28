using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veripark.Assigment.Data.Models;
using Veripark.Assigment.Data.Repository.Interfaces;

namespace Veripark.Assigment.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CountryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> AllCountries => _appDbContext.Countries;

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.Include(h => h.Holidays).FirstOrDefault(c => c.Id == countryId);
        }
    }
}
