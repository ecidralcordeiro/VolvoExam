using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private static readonly List<Vehicle> _vehicles = new();

    // Insert a new vehicle
    [HttpPost]
    public IActionResult CreateVehicle([FromBody] VehicleDto dto)
    {
        string chassisId = $"{dto.ChassisSeries}-{dto.ChassisNumber}";
        if (_vehicles.Any(v => v.Chassis.Id == chassisId))
        {
            return Conflict($"Vehicle with ChassisId {chassisId} already exists.");
        }

        var chassis = new Chassis
        {
            ChassisSeries = dto.ChassisSeries,
            ChassisNumber = dto.ChassisNumber
        };

        var vehicle = new Vehicle(chassis, dto.Type, dto.Color);
        _vehicles.Add(vehicle);
        return CreatedAtAction(nameof(GetByChassisId), new { chassisId = chassis.Id }, vehicle);
    }

    // Edit an existing vehicle (change color only)
    [HttpPut("{chassisId}/color")]
    public IActionResult UpdateColor(string chassisId, [FromBody] string newColor)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Chassis.Id == chassisId);
        if (vehicle == null)
        {
            return NotFound($"Vehicle with ChassisId {chassisId} not found.");
        }

        vehicle.Color = newColor;
        return Ok(vehicle);
    }

    // List all vehicles
    [HttpGet]
    public ActionResult<List<Vehicle>> GetAll()
    {
        return Ok(_vehicles);
    }

    // Find a vehicle by chassisId
    [HttpGet("{chassisId}")]
    public IActionResult GetByChassisId(string chassisId)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Chassis.Id == chassisId);
        if (vehicle == null)
        {
            return NotFound($"Vehicle with ChassisId {chassisId} not found.");
        }

        return Ok(vehicle);
    }
}
