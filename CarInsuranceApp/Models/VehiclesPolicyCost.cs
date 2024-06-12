namespace CarInsuranceApp.Models;

public class VehiclesPolicyCost
{
    public double Amount { get; set; }

    public VehiclesPolicyCost(double amount)
    {
        Amount = amount;
    }
}