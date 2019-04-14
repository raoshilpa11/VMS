using System.Collections.Generic;
using VMS.Models;
using VMS.Repository;

namespace VMS.Service
{
    public class VehiclesService : IVehiclesService
    {
        //VehicleRepository vehicleRepository = new VehicleRepository();
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public List<Vehicles> FetchVehicle()
        {
            List<Vehicles> car = new List<Vehicles>();
            car = _vehicleRepository.FetchVehicle();
            return car;
        }

        public List<Vehicletype> LoadVehicleTypeList()
        {
            return _vehicleRepository.LoadVehicleTypeList();
        }

        public VehicleMakemodelMapping GetMakeModelIDList(VehicleMakemodelMapping mapping, decimal VmakeId, decimal VmodelId)
        {
            return _vehicleRepository.GetMakeModelIDList(mapping, VmakeId, VmodelId);
        }

        public void InsertIntoVehicleRecordProperties(VehiclesModel vehicles, decimal id)
        {
            _vehicleRepository.InsertIntoVehicleRecordProperties(vehicles, id);
        }

        public void Delete(decimal recordID)
        {
            _vehicleRepository.Delete(recordID);
        }
    }
}
