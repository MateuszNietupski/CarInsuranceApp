using CarInsuranceApp.Enums;

namespace CarInsuranceApp.Models;

public class VehicleModelRiskFact
{
    public string Model { get; set; }
    public VehicleRiskType RiskType { get; set; }
}