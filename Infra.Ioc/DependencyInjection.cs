using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationDbContext>(options =>{}); If you can change the repository to Data BaseO

        //Cors


        // Config AutoMapper
        services.AddAutoMapper(typeof(VehicleMappingProfile));

        // Repositories
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        // Services
        services.AddScoped<IVehicleService, VehicleService>();

        return services;
    }
}
