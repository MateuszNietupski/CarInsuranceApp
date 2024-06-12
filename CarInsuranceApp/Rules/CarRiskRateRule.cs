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
            .Match(() => vehicle)
            .Match<VehicleModelRiskFact>(() => vehicleModelRiskFact, mrf => mrf.Model.Equals(vehicle.Model));
        Then()
            .Do(ctx => ctx.Insert(new AutoRisk(vehicleModelRiskFact.RiskType,vehicle.Id)));
        Priority(5);
    }
}
