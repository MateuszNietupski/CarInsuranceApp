using NRules.Fluent.Dsl;
using NRules.RuleModel;
using CarInsuranceApp.Enums;
using CarInsuranceApp.Models;

namespace CarInsuranceApp.Rules;

public class CarRiskRateRule : Rule
{
    public override void Define()
    {
        VehicleModelRiskFact vehicleModelRiskFact = null;
        Vehicle vehicle = null;

        When()
            .Match(() => vehicle, v => v.Type.Equals(null))
            .Match<VehicleModelRiskFact>(() => vehicleModelRiskFact, mrf => mrf.Model.Equals(vehicle.Model));
        Then()
            .Do(ctx => ctx.Insert(new Vehicle(vehicle.Id, vehicle.Age, vehicle.Model, vehicle.Mileage,
                vehicleModelRiskFact.RiskType)))
            .Do(ctx => ctx.Retract(vehicle));
        Priority(5);
    }
}
