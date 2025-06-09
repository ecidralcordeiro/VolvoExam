using Infra.Data.Repositories;
using Xunit;
using FluentAssertions;

public class VehicleRepositoryTests
{
    [Fact]
    public void CreateVehicle_Should_Add_And_Return_Vehicle()
    {
        var repo = new VehicleRepository();
        var chassis = new Chassis { ChassisSeries = "A", ChassisNumber = 1 };
        var vehicle = new Vehicle(chassis, VehicleType.Car, "Blue");

        var result = repo.CreateVehicle(vehicle);

        result.Should().Be(vehicle);
        repo.GetAllVehicles().Should().Contain(vehicle);
    }

    [Fact]
    public void GetVehicleByChassisId_Should_Return_Correct_Vehicle()
    {
        var repo = new VehicleRepository();
        var chassis = new Chassis { ChassisSeries = "B", ChassisNumber = 2 };
        var vehicle = new Vehicle(chassis, VehicleType.Bus, "Yellow");
        repo.CreateVehicle(vehicle);

        var found = repo.GetVehicleByChassisId(chassis.Id);

        found.Should().Be(vehicle);
    }

    [Fact]
    public void UpdateVehicleColor_Should_Change_Color()
    {
        var repo = new VehicleRepository();
        var chassis = new Chassis { ChassisSeries = "C", ChassisNumber = 3 };
        var vehicle = new Vehicle(chassis, VehicleType.Truck, "White");
        repo.CreateVehicle(vehicle);

        var updated = repo.UpdateVehicleColor(chassis.Id, "Black");

        updated.Color.Should().Be("Black");
    }
}