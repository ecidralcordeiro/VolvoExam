using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    public VehicleController(IVehicleService userService)
    {
        _vehicleService = userService;
    }
    // Insert a new vehicle
    [HttpPost]
    public IActionResult CreateVehicle([FromBody] VehicleDto vehicleDto)
    {
        _vehicleService.CreateVehicle(vehicleDto);
        return CreatedAtAction(nameof(GetByChassisId), new { chassisId = vehicleDto }, vehicleDto);
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
