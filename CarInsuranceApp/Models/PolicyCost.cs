namespace CarInsuranceApp.Models;

public class PolicyCost
{
    public double Cost { get; set; }

    public PolicyCost(double charges)
    {
        Cost = charges;
    }
}