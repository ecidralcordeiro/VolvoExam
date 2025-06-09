using Domain.Interfaces;
namespace Infra.Data.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private static readonly List<Vehicle> _vehicles = new();

    public Vehicle CreateVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
        return vehicle;
    }

    public Vehicle UpdateVehicleColor(string chassisId, string newColor)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Chassis.Id == chassisId);
        if (vehicle == null)
            return null;
        vehicle.Color = newColor;
        return vehicle;
    }

    public Vehicle GetVehicleByChassisId(string chassisId)
    {
        return _vehicles.FirstOrDefault(v => v.Chassis.Id == chassisId);
    }

    public List<Vehicle> GetAllVehicles()
    {
        return _vehicles.ToList();
    }
}
