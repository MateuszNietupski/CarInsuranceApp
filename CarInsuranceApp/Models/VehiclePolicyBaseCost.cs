namespace CarInsuranceApp.Models;

public class VehiclePolicyBaseCost
{
    public int VehicleId { get; set; }
    public double Amount { get; set; } = 500;

    public VehiclePolicyBaseCost(int vehicleId, double amount)
    {
        VehicleId = vehicleId;
        Amount += amount;
    }
}