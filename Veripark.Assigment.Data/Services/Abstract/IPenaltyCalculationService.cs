using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veripark.Assigment.Data.ViewModels;

namespace Veripark.Assigment.Data.Services.Abstract
{
    public interface IPenaltyCalculationService
    {
        dynamic Calculate(int penaltyDays, string currency);
        int GetBusinessDays(PenaltyCalculationViewModel model);
    }
}
