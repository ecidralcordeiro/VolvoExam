using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;
using System.Collections.Generic;

public class VehicleServiceTests
{
    private readonly Mock<IVehicleRepository> _repoMock;
    private readonly IMapper _mapper;
    private readonly VehicleService _service;

    public VehicleServiceTests()
    {
        _repoMock = new Mock<IVehicleRepository>();
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Application.Mappings.VehicleMappingProfile>());
        _mapper = config.CreateMapper();
        _service = new VehicleService(_repoMock.Object, _mapper);
    }

    [Fact]
    public void CreateVehicle_Should_Throw_If_Chassis_Exists()
    {
        var dto = new VehicleDtoCreate { ChassisSeries = "A", ChassisNumber = 1, Type = VehicleType.Car, Color = "Red" };
        var chassis = new Chassis { ChassisSeries = "A", ChassisNumber = 1 };
        var vehicle = new Vehicle(chassis, VehicleType.Car, "Red");
        _repoMock.Setup(r => r.GetVehicleByChassisId(chassis.Id)).Returns(vehicle);

        var act = () => _service.CreateVehicle(dto);

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetAllVehicles_Should_Return_Mapped_Dtos()
    {
        var vehicles = new List<Vehicle>
        {
            new Vehicle(new Chassis { ChassisSeries = "A", ChassisNumber = 1 }, VehicleType.Car, "Red")
        };
        _repoMock.Setup(r => r.GetAllVehicles()).Returns(vehicles);

        var result = _service.GetAllVehicles();

        result.Should().HaveCount(1);
        result[0].ChassisSeries.Should().Be("A");
    }
}