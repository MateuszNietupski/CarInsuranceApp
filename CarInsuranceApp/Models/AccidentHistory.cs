namespace CarInsuranceApp.Models;

public class AccidentHistory
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime AccidentDate { get; set; } = DateTime.Now;
    
    public AccidentHistory(int id)
    {
        Id = id;
    }
}