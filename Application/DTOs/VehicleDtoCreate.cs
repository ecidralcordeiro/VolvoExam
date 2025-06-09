using System.ComponentModel.DataAnnotations;

public class VehicleDtoCreate
{
    [Required]
    public string ChassisSeries { get; set; }

    [Required]
    [Range(1, uint.MaxValue, ErrorMessage = "ChassisNumber must be a positive integer.")]
    public uint ChassisNumber { get; set; }

    [Required]
    [EnumDataType(typeof(VehicleType))]
    public VehicleType Type { get; set; }

    [Required]
    [MinLength(1)]
    public string Color { get; set; }

}
