using CarInsuranceApp.Enums;
using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class PremiumCarRiskRule : Rule
{
    public override void Define()
    {
        AutoRisk autoRisk = null;

        When()
            .Match(() => autoRisk, ar => ar.RiskType.Equals(VehicleRiskType.Premium));
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(autoRisk.VehicleID, 500 * 2,
                "Naliczono opłate 200% za auto premium")));
        Priority(4);
    }
}