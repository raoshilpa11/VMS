using System.Collections.Generic;
using VMS.Models;

namespace VMS.Repository
{
    public interface IVehicleRepository
    {
        List<Vehicles> FetchVehicle();
        List<Vehicletype> LoadVehicleTypeList();
        VehicleMakemodelMapping GetMakeModelIDList(VehicleMakemodelMapping mapping, decimal VmakeId, decimal VmodelId);
        void InsertIntoVehicleRecordProperties(VehiclesModel vehicles, decimal id);
        void Delete(decimal recordID);
    }
}
