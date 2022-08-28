using Microsoft.Extensions.DependencyInjection.FactoryPattern;

namespace Veripark.Assigment.Data.Services.Abstract
{
    public  interface IPenaltyCalculationServiceFactoryPatternResolver :IFactoryPatternResolver<IPenaltyCalculationService, Enum.Country>
    {
    }
}
