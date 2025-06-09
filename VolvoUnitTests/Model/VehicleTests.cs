using Xunit;
using FluentAssertions;

public class VehicleTests
{
    [Theory]
    [InlineData(VehicleType.Truck, 1)]
    [InlineData(VehicleType.Bus, 42)]
    [InlineData(VehicleType.Car, 4)]
    public void Vehicle_Should_Set_Correct_NumberOfPassengers(VehicleType type, int expectedPassengers)
    {
        var chassis = new Chassis { ChassisSeries = "ABC", ChassisNumber = 123 };
        var vehicle = new Vehicle(chassis, type, "Red");

        vehicle.NumberOfPassengers.Should().Be(expectedPassengers);
    }

    [Fact]
    public void Chassis_Id_Should_Concatenate_Series_And_Number()
    {
        var chassis = new Chassis { ChassisSeries = "XYZ", ChassisNumber = 999 };
        chassis.Id.Should().Be("XYZ-999");
    }
}