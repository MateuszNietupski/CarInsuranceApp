using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class CalculateFinalPolicyCostRule : Rule
{
    public override void Define()
    {
        IEnumerable<PolicyActionLog> charges = null;
        VehiclesPolicyCost vehiclesPolicyCost = null;
        When()
            .Query(() => charges, q => q
                .Match<PolicyActionLog>()
                .Collect())
            .Match(() => vehiclesPolicyCost);
        Then()
            .Do(ctx => ctx.Insert(new PolicyCost(vehiclesPolicyCost.Amount + charges.Sum(c => c.Amount))));
        Priority(0);
    }
}
