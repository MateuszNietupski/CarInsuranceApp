using CarInsuranceApp.Enums;
using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class HighRiskVehicleRule : Rule
{
    public override void Define()
    {
        Vehicle vehicle = null;
        When()
            .Match(() => vehicle, v => v.Type.Equals(VehicleRiskType.HighRisk));
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(vehicle.Id, 500 * 0.2,
                "Naliczono opłate 20% za auto wysokiego ryzyka")));
        Priority(4);
    }
}