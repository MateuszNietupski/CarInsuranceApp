using CarInsuranceApp.Enums;
using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class HighRiskVehicleRule : Rule
{
    public override void Define()
    {
        AutoRisk autoRisk = null;
        When()
            .Match(() => autoRisk, ar => ar.RiskType.Equals(VehicleRiskType.HighRisk));
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(autoRisk.VehicleID, 500,
                "Naliczono opłate 100% za auto wysokiego ryzyka")));
        Priority(4);
    }
}