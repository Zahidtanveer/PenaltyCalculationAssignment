using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Veripark.Assigment.Data.Services.Abstract;
using Veripark.Assigment.Data.ViewModels;

namespace Veripark.Assigment.Data.Services.Concrete
{
    public class TurkeyPenaltyCalculationService : IPenaltyCalculationService
    {
        private readonly decimal PenaltyForEachDayPrice = 5;
        private readonly int PenaltyDaysLimit = 10;

        public dynamic Calculate(int days, string currency)
        {
            var TotalPrice = days > PenaltyDaysLimit ? (days - PenaltyDaysLimit) * PenaltyForEachDayPrice : 0;

            var CurrencySymbol = new RegionInfo(currency.Trim()).CurrencySymbol.ToString();

            return new { TotalPrice = TotalPrice, Currency = CurrencySymbol };
        }

        public int GetBusinessDays(PenaltyCalculationViewModel model)
        {
            int TotalBusinessDays = 0;

            var holidays = model.Country.Holidays.Select(s => s.Date);

            var dayDifference = (int)model.To.Subtract(model.From).TotalDays;

            for (var date = model.From; date <= model.To; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Contains(date))
                    TotalBusinessDays++;
            }

            return TotalBusinessDays;
        }
    }
}
