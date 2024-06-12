using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class CalculateVehiclePolicyBaseCost : Rule
{
    public override void Define()
    {
        IEnumerable<CarPolicyActionLog> charges = null;
        Vehicle vehicle = null;
        When()
            .Match(() => vehicle)
            .Query(() => charges, q => q
                .Match<CarPolicyActionLog>(c => c.VehicleId.Equals(vehicle.Id))
                .Collect());
        Then()
            .Do(ctx => ctx.Insert(new VehiclePolicyBaseCost(vehicle.Id, charges.Sum(c => c.Amount))));
        Priority(3);
    }
}