namespace CarInsuranceApp.Models;

public class PolicyActionLog
{
    public double Amount { get; set; }
    public string? Description { get; set; }

    public PolicyActionLog(double amount, string description)
    {
        Amount = amount;
        Description = description;
    }
}