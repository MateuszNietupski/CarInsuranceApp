using CarInsuranceApp.Enums;

namespace CarInsuranceApp.Models;

public class Vehicle
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Model { get; set; }
    public int Mileage { get; set; }
    public VehicleRiskType Type { get; set; }

    public Vehicle(int id,int age, string model, int mileage)
    {
        Id = id;
        Age = age;
        Model = model;
        Mileage = mileage;
    }
    public Vehicle(int id,int age, string model, int mileage, VehicleRiskType type)
    {
        Id = id;
        Age = age;
        Model = model;
        Mileage = mileage;
        Type = type;
    }

    public Vehicle(int id)
    {
        Id = id;
    }

    public Vehicle()
    {
    }
}