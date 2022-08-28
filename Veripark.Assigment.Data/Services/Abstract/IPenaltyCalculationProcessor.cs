using Veripark.Assigment.Data.ViewModels;

namespace Veripark.Assigment.Data.Services.Abstract
{
    public interface IPenaltyCalculationProcessor
    {
        PenaltyDisplayViewModel Process(PenaltyCalculationViewModel model);
    }
}