using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    // Insert a new vehicle
    [HttpPost]
    public IActionResult CreateVehicle([FromBody] VehicleDto vehicleDto)
    {
        try
        {
            var created = _vehicleService.CreateVehicle(vehicleDto);
            return CreatedAtAction(nameof(GetByChassisId), new { chassisId = $"{vehicleDto.ChassisSeries}-{vehicleDto.ChassisNumber}" }, created);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    // Edit an existing vehicle (change color only)
    [HttpPut("{chassisId}/color")]
    public IActionResult UpdateColor(string chassisId, [FromBody] string newColor)
    {
            try
        {
            var updated = _vehicleService.UpdateVehicleColor(chassisId, newColor);
            return Ok(updated);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // List all vehicles
    [HttpGet]
    public ActionResult<List<VehicleDto>> GetAll()
    {
        var vehicles = _vehicleService.GetAllVehicles();
        return Ok(vehicles);
    }

    // Find a vehicle by chassisId
    [HttpGet("{chassisId}")]
    public IActionResult GetByChassisId(string chassisId)
    {
        try
        {
            var vehicle = _vehicleService.GetVehicleByChassisId(chassisId);
            return Ok(vehicle);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
