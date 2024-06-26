using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class AccidentHistoryRule : Rule
{
    public override void Define()
    {
        AccidentHistory accidentHistory = default;
        VehiclePolicyBaseCost vehiclesPolicyCost = null;
        When()
            .Match(() => vehiclesPolicyCost)
            .Match(() => accidentHistory);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(
                 (DateTime.Now - accidentHistory.AccidentDate).TotalDays < 1825
                    ? vehiclesPolicyCost.Amount * 0.2
                    : vehiclesPolicyCost.Amount * 0.1,
                $"Naliczono opłate za historię wypadków {((DateTime.Now - accidentHistory.AccidentDate).TotalDays < 1825 ? 20 :10)}%")));
        Priority(1);
    }
}