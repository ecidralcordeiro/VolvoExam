public class Chassis
{
    public string ChassisSeries { get; set; }
    public uint ChassisNumber { get; set; }
    public string Id => $"{ChassisSeries}-{ChassisNumber}";
}