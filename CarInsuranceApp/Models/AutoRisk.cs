using CarInsuranceApp.Enums;

namespace CarInsuranceApp.Models;

public class AutoRisk
{
    public VehicleRiskType RiskType { get; set; }
    public int VehicleID { get; set; }
    public AutoRisk(VehicleRiskType riskType,int vehicleId)
    {
        VehicleID = vehicleId;
        RiskType = riskType;
    }
}