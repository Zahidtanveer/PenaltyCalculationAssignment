using System;
using Veripark.Assigment.Data.Services.Abstract;
using Veripark.Assigment.Data.ViewModels;

namespace Veripark.Assigment.Data.Services.Concrete
{
    public class PenaltyCalculationProcessor : IPenaltyCalculationProcessor
    {
        private readonly IPenaltyCalculationServiceFactoryPatternResolver _factoryPatternResolver;

        public PenaltyCalculationProcessor(IPenaltyCalculationServiceFactoryPatternResolver factoryPatternResolver)
        {
            _factoryPatternResolver = factoryPatternResolver;
        }

        public PenaltyDisplayViewModel Process(PenaltyCalculationViewModel inputViewModel)
        {
            if (inputViewModel == null)
                throw new Exception($"{typeof(PenaltyCalculationViewModel).FullName} can not be null!");
            try
            {
                var _countryEnum = (Enum.Country)System.Enum.Parse(typeof(Enum.Country), inputViewModel.Country.Currency);

                var _penaltyCalculationService = _factoryPatternResolver.Resolve(_countryEnum);

                var businessDays = _penaltyCalculationService.GetBusinessDays(inputViewModel);

                var result = _penaltyCalculationService.Calculate(businessDays, inputViewModel.Country.Currency);

                return new PenaltyDisplayViewModel { BusinessDays = businessDays, TotalPrice = result.TotalPrice, CurrencySymbol = result.Currency };
            }
            catch
            {
                
            }
            return new PenaltyDisplayViewModel();
            
        }
    }
}
