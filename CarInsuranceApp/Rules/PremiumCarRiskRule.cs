using CarInsuranceApp.Enums;
using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class PremiumCarRiskRule : Rule
{
    public override void Define()
    {
        Vehicle vehicle = null;

        When()
            .Match(() => vehicle, v => v.Type.Equals(VehicleRiskType.Premium));
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(vehicle.Id, 500 * 0.4,
                "Naliczono opłate 40% za auto premium")));
        Priority(4);
    }
}