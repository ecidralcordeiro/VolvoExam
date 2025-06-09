using API.Controllers;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;

public class VehicleControllerTests
{
    private readonly Mock<IVehicleService> _serviceMock;
    private readonly VehicleController _controller;

    public VehicleControllerTests()
    {
        _serviceMock = new Mock<IVehicleService>();
        _controller = new VehicleController(_serviceMock.Object);
    }

    [Fact]
    public void GetAll_Should_Return_Ok_With_List()
    {
        _serviceMock.Setup(s => s.GetAllVehicles()).Returns(new List<VehicleDto>());

        var result = _controller.GetAll();

        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void CreateVehicle_Should_Return_Conflict_If_Exists()
    {
        _serviceMock.Setup(s => s.CreateVehicle(It.IsAny<VehicleDtoCreate>())).Throws<InvalidOperationException>();

        var result = _controller.CreateVehicle(new VehicleDtoCreate());

        Assert.IsType<ConflictObjectResult>(result);
    }
}