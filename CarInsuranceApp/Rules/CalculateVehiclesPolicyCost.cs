using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class CalculateVehiclesPolicyCost : Rule
{
    public override void Define()
    {
        IEnumerable<VehiclePolicyBaseCost> charges = null;
        
        
        When()
            .Query(() => charges, q => q
                .Match<VehiclePolicyBaseCost>()
                .Collect());
        Then()
            .Do(ctx => ctx.Insert(new VehiclesPolicyCost(charges.Sum(c => c.Amount))));
        Priority(2);
    }
}