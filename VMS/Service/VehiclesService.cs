using System.Collections.Generic;
using VMS.Models;
using VMS.Repository;

namespace VMS.Service
{
    public class VehiclesService
    {
        VehicleRepository VR = new VehicleRepository();

        public List<Vehicles> FetchCars(int Id)
        {
            List<Vehicles> car = new List<Vehicles>();
            car = VR.FetchCars1(Id);
            return car;
        }

        public List<Vehicletype> LoadVehicleTypeList()
        {
            return VR.LoadVehicleTypes();
        }

        public VehicleMakemodelMapping GetMakeModelIDList(VehicleMakemodelMapping mapping, decimal VmakeId, decimal VmodelId)
        {
            return VR.GetMakeModelIDs(mapping, VmakeId, VmodelId);
        }

        public void InsertIntoVehicleRecordProperties(VehiclesModel vehicles, decimal id)
        {
            VR.InsertIntoVehicleRecordProperties(vehicles, id);
        }
    }
}
