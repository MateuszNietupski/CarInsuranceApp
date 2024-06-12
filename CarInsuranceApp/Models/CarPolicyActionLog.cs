namespace CarInsuranceApp.Models;

public class CarPolicyActionLog
{
    public int VehicleId { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }

    public CarPolicyActionLog(int vehicleId, double amount, string description)
    {
        VehicleId = vehicleId;
        Amount = amount;
        Description = description;
    }
}