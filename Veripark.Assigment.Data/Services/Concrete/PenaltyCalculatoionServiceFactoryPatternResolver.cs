using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using System;
using Veripark.Assigment.Data;
using Veripark.Assigment.Data.Services.Abstract;

namespace Veripark.Assigment.Data.Services.Concrete
{
    public class PenaltyCalculationServiceFactoryPatternResolver : FactoryPatternResolver<IPenaltyCalculationService, Enum.Country>, IPenaltyCalculationServiceFactoryPatternResolver
    {

        public PenaltyCalculationServiceFactoryPatternResolver(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            
        }
    }
}
