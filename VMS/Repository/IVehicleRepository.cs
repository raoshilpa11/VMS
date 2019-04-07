using System.Collections.Generic;
using VMS.Models;

namespace VMS.Repository
{
    public interface IVehicleRepository
    {
        List<Vehicles> FetchCars(int id);
    }
}
