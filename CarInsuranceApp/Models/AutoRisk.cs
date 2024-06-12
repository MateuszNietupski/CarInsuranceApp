using CarInsuranceApp.Enums;

namespace CarInsuranceApp.Models;

public class AutoRisk
{
    public VehicleRiskType RiskType { get; set; }

    public AutoRisk(VehicleRiskType riskType)
    {
        RiskType = riskType;
    }
}