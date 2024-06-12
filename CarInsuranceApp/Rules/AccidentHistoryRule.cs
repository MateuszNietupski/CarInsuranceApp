using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class AccidentHistoryRule : Rule
{
    public override void Define()
    {
        Driver driver = default;
        VehiclePolicyBaseCost vehiclesPolicyCost = null;
        When()
            .Match(() => vehiclesPolicyCost)
            .Match<Driver>(() => driver, d => d.AccidentHistories != null && d.AccidentHistories.Count > 0);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(
                driver.AccidentHistories.Any(a => (DateTime.Now - a.AccidentDate).TotalDays < 1825)
                    ? vehiclesPolicyCost.Amount * 0.2
                    : vehiclesPolicyCost.Amount * 0.1,
                $"Naliczono opłate za historię wypadków {(driver.AccidentHistories.Any(a => (DateTime.Now - a.AccidentDate).TotalDays < 1825) ? 500 * 0.2 : 500 * 0.1)}")));
        Priority(1);
    }
}