using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

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
    public VehicleDto CreateVehicle(VehicleDto vehicleDto)
    {
        // Verifica unicidade do chassi
        string chassisId = $"{vehicleDto.ChassisSeries}-{vehicleDto.ChassisNumber}";
        var existing = _repository.GetVehicleByChassisId(chassisId);
        if (existing != null)
            throw new InvalidOperationException($"Vehicle with ChassisId {chassisId} already exists.");

        var vehicle = _mapper.Map<Vehicle>(vehicleDto);
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