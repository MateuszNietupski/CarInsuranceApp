using System.Drawing;
using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class AgeRule : Rule
{
    public override void Define()
    {
        Driver driver = null;
        VehiclesPolicyCost vehiclesPolicyCost = null;
        When()
            .Match(() => vehiclesPolicyCost)
            .Match<Driver>(() => driver, d => d.Age < 25 || d.Age > 65);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(vehiclesPolicyCost.Amount * 0.2,
                "Naliczono opłąte za wiek 20%")));
        Priority(1);
    }
}