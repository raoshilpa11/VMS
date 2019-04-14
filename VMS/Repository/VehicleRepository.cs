using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using VMS.Models;

namespace VMS.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        //VehiclesContext _modelContext = new VehiclesContext();

        private VehiclesContext _modelContext;
        public VehicleRepository(VehiclesContext sc)
        {
            _modelContext = sc;
        }

        public List<Vehicles> FetchVehicle()
        {
            List<Vehicles> carList = new List<Vehicles>();

            //using (var context = new VehiclesContext())
            //{
                string query1 = @"SELECT R.VR_ID VRId, T.VT_ID VtId, MMM.VMMP_ID VMMPId, T.VEHICLETYPE_NAME Type,
                            MAKE.VEHICLEMAKE_NAME Make,
                            MAKE.VMAKE_ID VmakeId, MODELS.VEHICLEMODEL_NAME Model, MODELS.VMODEL_ID VmodelId
                            FROM VEHICLE_RECORDS R
				            LEFT JOIN VEHICLE_MAKEMODEL_MAPPING MMM
				            ON R.VMMP_ID = MMM.VMMP_ID
				            LEFT JOIN VEHICLETYPE T
				            ON MMM.VT_ID = T.VT_ID
				            LEFT OUTER JOIN VEHICLE_MAKE MAKE
                            ON MMM.VMAKE_ID = MAKE.VMAKE_ID 
                            LEFT OUTER JOIN VEHICLE_MODEL MODELS
                            ON MMM.VMODEL_ID = MODELS.VMODEL_ID
                            WHERE                 
                            --AND R.VR_ID = 1
                            MMM.VT_ID = 1";

                var results = _modelContext.Vehicles.FromSql(query1).ToList();

                foreach (var result in results)
                {
                    Vehicles car = new Vehicles();

                    car.VRId = result.VRId;
                    car.VMMPId = result.VMMPId;
                    car.VtId = result.VtId;
                    car.Type = result.Type;
                    car.Make = result.Make;
                    car.Model = result.Model;

                    carList.Add(car);
                }
            //}
            //using (var modelContext = new VehiclesContext())
            //{
                foreach (var result in carList)
                {
                    string query2 = @"SELECT VRP.VPM_ID VPM, VRP.VALUE
                    FROM VEHICLE_RECORDS R FULL OUTER JOIN VEHICLE_RECORDS_PROPERTIES VRP
                    ON R.VR_ID = VRP.VR_ID
                    LEFT JOIN VEHICLE_MAKEMODEL_MAPPING VMM
                    ON R.VMMP_ID = VMM.VMMP_ID
                    LEFT JOIN VEHICLETYPE T
				    ON VMM.VT_ID = T.VT_ID                    
                    WHERE R.VR_ID = @s";

                    SqlParameter parameterS = new SqlParameter("@s", result.VRId);

                    var carProperties = _modelContext.Cars.FromSql(query2, parameterS).ToList();

                    List<Car> carPropertyList = new List<Car>();
                    if (carProperties != null)
                        foreach (var carProperty in carProperties)
                        {
                            Car carProp = new Car();
                            carProp.VPM = carProperty.VPM;
                            carProp.Value = carProperty.Value;

                            carPropertyList.Add(carProp);
                        }
                    result.Car = carPropertyList;
                }
            //}
            return carList;
        }

        public List<Vehicletype> LoadVehicleTypeList()
        {
            List<Vehicletype> vehicleType = new List<Vehicletype>();

            vehicleType = (from vehicle in _modelContext.Vehicletype where vehicle.IsActive.Equals('Y') select vehicle).ToList();
            vehicleType.Insert(0, new Vehicletype { VtId = 0, VehicletypeName = "Select" });

            return vehicleType;
        }

        public VehicleMakemodelMapping GetMakeModelIDList(VehicleMakemodelMapping mapping, decimal VmakeId, decimal VmodelId)
        {
            mapping = (from mmm in _modelContext.VehicleMakemodelMapping
                       where mmm.VmakeId.Equals(VmakeId)
                       && mmm.VmodelId.Equals(VmodelId)
                       && mmm.IsActive.Equals('Y')
                       select mmm).FirstOrDefault();

            return mapping;
        }

        public void InsertIntoVehicleRecordProperties(VehiclesModel vehicles, decimal id)
        {
            if (!string.IsNullOrEmpty(vehicles.Engine))
            {
                var recordProperty = new VehicleRecordsProperties()
                {
                    VrId = id,
                    VpmId = 2,
                    Value = vehicles.Engine
                };
                _modelContext.VehicleRecordsProperties.Add(recordProperty);
                _modelContext.SaveChanges();
            }
            if (!string.IsNullOrEmpty(vehicles.Doors))
            {
                var recordProperty = new VehicleRecordsProperties()
                {
                    VrId = id,
                    VpmId = 3,
                    Value = vehicles.Doors
                };
                _modelContext.VehicleRecordsProperties.Add(recordProperty);
                _modelContext.SaveChanges();
            }
            if (!string.IsNullOrEmpty(vehicles.Wheels))
            {
                var recordProperty = new VehicleRecordsProperties()
                {
                    VrId = id,
                    VpmId = 4,
                    Value = vehicles.Wheels
                };
                _modelContext.VehicleRecordsProperties.Add(recordProperty);
                _modelContext.SaveChanges();
            }
            if (!string.IsNullOrEmpty(vehicles.BodyType))
            {
                var recordProperty = new VehicleRecordsProperties()
                {
                    VrId = id,
                    VpmId = 5,
                    Value = vehicles.BodyType
                };
                _modelContext.VehicleRecordsProperties.Add(recordProperty);
                _modelContext.SaveChanges();
            }
            if (!string.IsNullOrEmpty(vehicles.Colour))
            {
                var recordProperty = new VehicleRecordsProperties()
                {
                    VrId = id,
                    VpmId = 6,
                    Value = vehicles.Colour
                };
                _modelContext.VehicleRecordsProperties.Add(recordProperty);
                _modelContext.SaveChanges();
            }
        }

        public void Delete(decimal recordId)
        {
            List<VehicleRecordsProperties> vrProperties = _modelContext.VehicleRecordsProperties
                    .Where(e => e.VrId == recordId)
                    .ToList();
            if (vrProperties != null)
            {
                foreach (VehicleRecordsProperties vr in vrProperties)
                    _modelContext.VehicleRecordsProperties.Remove(vr);
            }
            _modelContext.SaveChanges();

            var VRPRecords = _modelContext.VehicleRecordsProperties
                    .Where(e => e.VrId == recordId)
                    .ToList();
            if (VRPRecords.Count == 0)
            {
                VehicleRecords deleteVehicleRecord = _modelContext.VehicleRecords.Find(recordId);
                _modelContext.VehicleRecords.Remove(deleteVehicleRecord);
                _modelContext.SaveChanges();
            }
        }

        public void Update(VehiclesModel vehicle)
        {
            var vehicleRecord = _modelContext.VehicleRecordsProperties.Include("VehicleRecords").Where(i => i.VrId == vehicle.VRId).ToList();
            foreach (var record in vehicleRecord)
            {
                if (record.VpmId == 2)
                    record.Value = vehicle.Engine;
                if (record.VpmId == 3)
                    record.Value = vehicle.Doors;
                if (record.VpmId == 4)
                    record.Value = vehicle.Wheels;
                if (record.VpmId == 5)
                    record.Value = vehicle.BodyType;
                if (record.VpmId == 6)
                    record.Value = vehicle.Colour;

                var entry = _modelContext.VehicleRecordsProperties.Update(record);
                entry.State = EntityState.Modified;
                _modelContext.SaveChanges();
            }
        }
    }
}
