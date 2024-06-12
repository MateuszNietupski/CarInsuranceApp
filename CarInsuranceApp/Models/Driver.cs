namespace CarInsuranceApp.Models;

public class Driver
{
    public int Age { get; set; }
    public int YearsOfExperience { get; set; }
    public string test { get; set; }
    
    public Driver(int age, int yearsOfExperience)
    {
        Age = age;
        YearsOfExperience = yearsOfExperience;
    }

    public Driver()
    {
    }
}