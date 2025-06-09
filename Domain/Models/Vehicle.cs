public class Vehicle
{
    public Chassis Chassis { get; set; }
    public VehicleType Type { get; set; }
    public int NumberOfPassengers { get; private set; }
    public string Color { get; set; }

    public Vehicle(Chassis chassis, VehicleType type, string color)
    {
        Chassis = chassis;
        Type = type;
        Color = color;
        NumberOfPassengers = GetPassengerCountByType(type);
    }

    private int GetPassengerCountByType(VehicleType type)
    {
        return type switch
        {
            VehicleType.Truck => 1,
            VehicleType.Bus => 42,
            VehicleType.Car => 4,
            _ => throw new ArgumentOutOfRangeException(nameof(type), "Unknown vehicle type")
        };
    }
}
