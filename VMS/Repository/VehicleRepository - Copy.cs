using CRUDADO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRUDADO.Repository
{
    public class VehicleRepository
    {
        //private readonly VehiclesContext _model1Context;

        //public VehicleRepository()
        //{
        //    //Configuration = configuration;
        //    //_model1Context = modelContext ?? throw new ArgumentNullException("modelContext");
        //}
        //public DbQuery<List<Car>> SomeModels { get; set; }

        public List<Vehicle1> FetchCars(int id)
        {
            List<Vehicle1> carList = new List<Vehicle1>();

            //var _modelContext = new VehiclesContext();

            //string Query = @"SELECT MMM.VMMP_ID ID, T.VEHICLETYPE_NAME TYPE, MAKE.VEHICLEMAKE_NAME MAKE, MODELS.VEHICLEMODEL_NAME MODEL
            //FROM VEHICLE_RECORDS VR, VEHICLE_MAKEMODEL_MAPPING MMM, VEHICLETYPE T, VEHICLE_MAKE MAKE, VEHICLE_MODEL MODELS  
            //WHERE VR.VMMP_ID = MMM.VMMP_ID
            //AND MMM.VT_ID = T.VT_ID
            //AND MMM.VMAKE_ID = MAKE.VMAKE_ID
            //AND MMM.VMODEL_ID = MODELS.VMODEL_ID
            //AND MMM.VT_ID = 1";

            //        string Query = @"SELECT RP.VRP_ID VId, T.VT_ID VtId, MMM.VMMP_ID Id, T.VEHICLETYPE_NAME Type, MAKE.VEHICLEMAKE_NAME Make,
            //MAKE.VMAKE_ID VmakeId, MODELS.VEHICLEMODEL_NAME Model, MODELS.VMODEL_ID VmodelId, RP.VPM_ID VPM, RP.VALUE
            //            FROM VEHICLE_MAKEMODEL_MAPPING MMM, VEHICLETYPE T, 
            //            VEHICLE_MAKE MAKE, VEHICLE_MODEL MODELS, VEHICLE_RECORDS R, VEHICLE_RECORDS_PROPERTIES RP  
            //            WHERE R.VMMP_ID = MMM.VMMP_ID
            //            AND MMM.VT_ID = T.VT_ID
            //            AND MMM.VMAKE_ID = MAKE.VMAKE_ID
            //            AND MMM.VMODEL_ID = MODELS.VMODEL_ID
            //            AND R.VR_ID = RP.VR_ID
            //            --AND R.VR_ID = 1
            //            AND MMM.VT_ID = 1";

            //        string Query = @"SELECT R.VR_ID VRId, T.VT_ID VtId, MMM.VMMP_ID Id, T.VEHICLETYPE_NAME Type, MAKE.VEHICLEMAKE_NAME Make,
            //MAKE.VMAKE_ID VmakeId, MODELS.VEHICLEMODEL_NAME Model, MODELS.VMODEL_ID VmodelId, RP.VPM_ID VPM, RP.VALUE
            //            FROM VEHICLE_RECORDS R FULL OUTER JOIN VEHICLE_RECORDS_PROPERTIES RP  
            //ON R.VR_ID = RP.VR_ID
            //LEFT OUTER JOIN VEHICLE_MAKEMODEL_MAPPING MMM
            //ON R.VMMP_ID = MMM.VMMP_ID
            //LEFT OUTER JOIN VEHICLETYPE T
            //ON MMM.VT_ID = T.VT_ID
            //            LEFT OUTER JOIN VEHICLE_MAKE MAKE
            //ON MMM.VMAKE_ID = MAKE.VMAKE_ID 
            //LEFT OUTER JOIN VEHICLE_MODEL MODELS
            //ON MMM.VMODEL_ID = MODELS.VMODEL_ID
            //            WHERE                 
            //            --AND R.VR_ID = 1
            //            MMM.VT_ID = 1";
            using (var context = new VehiclesContext())
            {
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

                var results = context.Vehicle1.FromSql(query1).ToList();

                foreach (var result in results)
                {
                    Vehicle1 car = new Vehicle1();

                    car.VRId = result.VRId;
                    car.VMMPId = result.VMMPId;
                    car.VtId = result.VtId;
                    car.Type = result.Type;
                    car.Make = result.Make;
                    car.Model = result.Model;

                    carList.Add(car);
                }
            }
            using (var modelContext = new VehiclesContext())
            {
                foreach (var result in carList)
                {
                    string query2 = @"SELECT VRP.VPM_ID VPM, VRP.VALUE
                    FROM VEHICLE_RECORDS R FULL OUTER JOIN VEHICLE_RECORDS_PROPERTIES VRP
                    ON R.VR_ID = VRP.VR_ID
                    LEFT JOIN VEHICLE_MAKEMODEL_MAPPING VMM
                    ON R.VMMP_ID = VMM.VMMP_ID
                    LEFT JOIN VEHICLETYPE T
				    ON VMM.VT_ID = T.VT_ID                    
                    WHERE R.VR_ID = {0}";

                    var carPropoerties = modelContext.Car11.FromSql(query2, result.VRId).ToList();

                    List<Car1> carPropertyList = new List<Car1>();
                    if (carPropoerties != null)
                        foreach (var carProperty in carPropoerties)
                        {
                            Car1 carProp = new Car1();
                            carProp.VPM = carProperty.VPM;
                            carProp.Value = carProperty.Value;

                            carPropertyList.Add(carProp);
                        }
                    result.Car = carPropertyList;
                }
            }

            //carList.Add(car);
            //string Query2 = @"SELECT RP.VPM_ID VPM, RP.VALUE FROM VEHICLE_RECORDS R, VEHICLE_RECORDS_PROPERTIES RP
            //                WHERE R.VR_ID = RP.VR_ID
            //                AND R.VR_ID = 1";
            //var results2 = _modelContext.Car1.FromSql(Query2).ToList();

            //foreach (var result in results2)
            //{
            //    car1.VPM = result.VPM;
            //    car1.Value = result.Value;

            //    car11.Add(car1);
            //}
            return carList;
        }
    }
}
