using CarInsuranceApp.Models;
using NRules.Fluent.Dsl;

namespace CarInsuranceApp.Rules;

public class CarMileageRule : Rule
{
    public override void Define()
    {
        Vehicle vehicle = null;
        
        When()
            .Match(() => vehicle, v => v.Mileage <= 50000);
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(vehicle.Id ,500 * 0.1 *-1,"Zastosowano zniżke za niski przebieg auta 10%")));
        Priority(4);
    }
}

public class CarMediumMileageRule : Rule
{
    public override void Define()
    {
        Vehicle vehicle = null;
        When()
            .Match(() => vehicle, v => v.Mileage > 50000 && v.Mileage <= 150000);
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(vehicle.Id ,500 * 0.05 *-1,"Zastosowano zniżke za średni przebieg auta 5%")));
        Priority(4);
    }
}
public class CarHighMileageRule : Rule
{
    public override void Define()
    {
        Vehicle vehicle = null;
        When()
            .Match(() => vehicle, v => v.Mileage > 150000);
        Then()
            .Do(ctx => ctx.Insert(new CarPolicyActionLog(vehicle.Id ,500 * 0.9 ,"Zastosowano karę za wysoki przebieg auta 10%")));
        Priority(4);
    }
}
