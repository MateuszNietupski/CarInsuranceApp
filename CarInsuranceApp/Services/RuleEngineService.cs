using CarInsuranceApp.Enums;
using CarInsuranceApp.Models;
using CarInsuranceApp.Rules;

namespace CarInsuranceApp.Services;
using NRules.Fluent;
using NRules;

public class RuleEngineService
{
    private readonly ISessionFactory  _sessionFactory;
    private  ISession _session;
    private readonly List<VehicleModelRiskFact> _predefinedVehiclesRiskFacts;
    
    public RuleEngineService()
    {
        var repository = new RuleRepository();
        repository.Load(x => x.From(typeof(CarRiskRateRule).Assembly));
        _sessionFactory = repository.Compile();
        _predefinedVehiclesRiskFacts = new List<VehicleModelRiskFact>
        {
            new VehicleModelRiskFact { Model = "BMW", RiskType = VehicleRiskType.HighRisk },
            new VehicleModelRiskFact { Model = "Mercedes", RiskType = VehicleRiskType.Premium },
            new VehicleModelRiskFact { Model = "Fiat", RiskType = VehicleRiskType.Standard },
            new VehicleModelRiskFact { Model = "Ferrari", RiskType = VehicleRiskType.Premium },
        };
    }
    public void RunEngine(Driver driver,List<Vehicle> vehicles)
    {
        _session = _sessionFactory.CreateSession();
        _session.Insert(driver);
        foreach (var vehicle in vehicles)
        {
            _session.Insert(vehicle);
        }
        
        foreach (var fact in _predefinedVehiclesRiskFacts)
        {
            _session.Insert(fact);
        }
        _session.Fire();
    }
    public List<T> GetFacts<T>()
    {
        return _session.Query<T>().ToList();
    }
    public List<string> GetPredefinedModels()
    {
        return _predefinedVehiclesRiskFacts.Select(m => m.Model).ToList();
    }
}