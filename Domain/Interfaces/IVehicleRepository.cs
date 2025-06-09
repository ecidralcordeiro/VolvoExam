namespace Domain.Interfaces;

public interface IVehicleRepository
{
    Vehicle CreateVehicle(Vehicle dto);
    Vehicle UpdateVehicleColor(string chassisId, string newColor);
    List<Vehicle> GetAllVehicles();
    Vehicle GetVehicleByChassisId(string chassisId);
}
