using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IVehicleService
{
    VehicleDto CreateVehicle(VehicleDtoCreate dto);
    VehicleDto UpdateVehicleColor(string chassisId, string newColor);
    List<VehicleDto> GetAllVehicles();
    VehicleDto GetVehicleByChassisId(string chassisId);
    
        
        
}
