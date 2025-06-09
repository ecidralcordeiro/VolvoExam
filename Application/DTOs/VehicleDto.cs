using System.ComponentModel.DataAnnotations;

public class VehicleDto
{
    [Required]
    public string ChassisSeries { get; set; }
    public uint ChassisNumber { get; set; }

    public VehicleType Type { get; set; }

    public string TypeText => Type.ToString();
 
    public string Color { get; set; }
    public string ChassisId { get; set; }
}
