using System.Collections.Generic;
using VMS.Models;
using VMS.Repository;

namespace VMS.Service
{
    public class VehiclesService
    {
        VehicleRepository vehicleRepository = new VehicleRepository();

        public List<Vehicles> FetchVehicle()
        {
            List<Vehicles> car = new List<Vehicles>();
            car = vehicleRepository.FetchVehicle();
            return car;
        }

        public List<Vehicletype> LoadVehicleTypeList()
        {
            return vehicleRepository.LoadVehicleTypes();
        }

        public VehicleMakemodelMapping GetMakeModelIDList(VehicleMakemodelMapping mapping, decimal VmakeId, decimal VmodelId)
        {
            return vehicleRepository.GetMakeModelIDs(mapping, VmakeId, VmodelId);
        }

        public void InsertIntoVehicleRecordProperties(VehiclesModel vehicles, decimal id)
        {
            vehicleRepository.InsertIntoVehicleRecordProperties(vehicles, id);
        }

        public void Delete(decimal recordID)
        {
            vehicleRepository.Delete(recordID);
        }
    }
}
