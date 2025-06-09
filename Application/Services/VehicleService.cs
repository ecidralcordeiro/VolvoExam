using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper _mapper;

    public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _repository = vehicleRepository;
        _mapper = mapper;
    }
    public VehicleDto CreateVehicle(VehicleDtoCreate vehicleDto)
    {
        var chassis = new Chassis
        {
            ChassisNumber = vehicleDto.ChassisNumber,
            ChassisSeries = vehicleDto.ChassisSeries
        };

        var vehicle = new Vehicle(chassis, vehicleDto.Type, vehicleDto.Color);

        var existing = _repository.GetVehicleByChassisId(vehicle.Chassis.Id);
        if (existing != null)
            throw new InvalidOperationException($"Vehicle with ChassisId {vehicle.Chassis.Id} already exists.");

        var createdVehicle = _repository.CreateVehicle(vehicle);
        return _mapper.Map<VehicleDto>(createdVehicle);
    }
   
    public List<VehicleDto> GetAllVehicles()
    {
        var vehicles = _repository.GetAllVehicles();
        return vehicles.Select(v => _mapper.Map<VehicleDto>(v)).ToList();
    }

    public VehicleDto GetVehicleByChassisId(string chassisId)
    {
        var vehicle = _repository.GetVehicleByChassisId(chassisId);
        if (vehicle == null)
            throw new KeyNotFoundException($"Vehicle with ChassisId {chassisId} not found.");
        return _mapper.Map<VehicleDto>(vehicle);
    }
    public VehicleDto UpdateVehicleColor(string chassisId, string newColor)
    {
        var updated = _repository.UpdateVehicleColor(chassisId, newColor);
        if (updated == null)
            throw new KeyNotFoundException($"Vehicle with ChassisId {chassisId} not found.");
        return _mapper.Map<VehicleDto>(updated);
    }
}