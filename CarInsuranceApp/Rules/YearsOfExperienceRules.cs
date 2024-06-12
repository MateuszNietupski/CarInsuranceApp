using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class YearsOfExperienceRules : Rule
{
    public override void Define()
    {
        Driver driver = null;
        VehiclesPolicyCost vehiclesPolicyCost = null;
        When()
            .Match(() => driver, d => d.YearsOfExperience >= 5 && d.YearsOfExperience < 10)
            .Match(() => vehiclesPolicyCost);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(vehiclesPolicyCost.Amount * 0.05 *-1, "Zastosowano zniżke za lata doświadczenia 5%")));
        Priority(1);

    }
}

public class YearsOfExperience10To15 : Rule
{
    public override void Define()
    {
        Driver driver = null;
        VehiclesPolicyCost vehiclesPolicyCost = null;
        When()
            .Match(() => driver, d => d.YearsOfExperience >= 10 && d.YearsOfExperience < 15)
            .Match(() => vehiclesPolicyCost);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(vehiclesPolicyCost.Amount * 0.1 * -1, "Zastosowano zniżkę za lata doświadczenia 10%")));
        Priority(1);
    }
}
public class YearsOfExperience15To20 : Rule
{
    public override void Define()
    {
        Driver driver = null;
        VehiclesPolicyCost vehiclesPolicyCost = null;
        When()
            .Match(() => driver, d => d.YearsOfExperience >= 15 && d.YearsOfExperience < 20)
            .Match(() => vehiclesPolicyCost);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(vehiclesPolicyCost.Amount * 0.15 * -1, "Zastosowano zniżkę za lata doświadczenia 15%")));
        Priority(1);
    }
}
public class YearsOfExperience20To25 : Rule
{
    public override void Define()
    {
        Driver driver = null;
        VehiclesPolicyCost vehiclesPolicyCost = null;
        When()
            .Match(() => driver, d => d.YearsOfExperience >= 20 && d.YearsOfExperience < 25)
            .Match(() => vehiclesPolicyCost);
        Then()
            .Do(ctx => ctx.Insert(new PolicyActionLog(vehiclesPolicyCost.Amount * 0.2 * -1, "Zastosowano zniżkę za lata doświadczenia 20%")));
        Priority(1);
    }
}