using System.Collections.Generic;
using VMS.Models;

namespace VMS.Service
{
    public interface IVehiclesService
    {
        List<Vehicles> FetchCars(int Id);
    }
}
