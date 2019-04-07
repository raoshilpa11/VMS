using VMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using VMS.Service;

namespace VMS.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        VehiclesService vs = new VehiclesService();

        public IActionResult Index()
        {
            var _modelContext = new VehiclesContext();
            List<Vehicles> carList = new List<Vehicles>();

            carList = vs.FetchCars(1);

            return View(carList);
        }

        public IActionResult Create()
        {            
            ViewBag.ListOfVehicles = vs.LoadVehicleTypeList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehiclesModel vehicles, IFormCollection formCollection)
        {
            VehicleMakemodelMapping mapping = new VehicleMakemodelMapping();
            var _modelContext = new VehiclesContext();

            Validation(vehicles);

            decimal VmakeId = Convert.ToDecimal(HttpContext.Request.Form["VmakeId"]);
            decimal VmodelId = Convert.ToDecimal(HttpContext.Request.Form["VmodelId"]);
            mapping = vs.GetMakeModelIDList(mapping, VmakeId, VmodelId);

            if (ModelState.IsValid)
            {
                if (mapping != null)
                {
                    var record = new VehicleRecords()
                    {
                        VmmpId = mapping.VmmpId
                    };

                    _modelContext.VehicleRecords.Add(record);
                    _modelContext.SaveChanges();

                    decimal id = record.VrId;

                    if (id != 0)
                    {
                        vs.InsertIntoVehicleRecordProperties(vehicles, id);
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListOfVehicles = vs.LoadVehicleTypeList();
                return View(vehicles);
            }
        }

        private void Validation(VehiclesModel vehicles)
        {
            if (vehicles.VtId == 0)
            {
                ModelState.AddModelError("", "Select Vehicle");
            }
            else if (vehicles.VmakeId == 0)
            {
                ModelState.AddModelError("", "Select Make");
            }
            else if (vehicles.VmodelId == 0)
            {
                ModelState.AddModelError("", "Select Model");
            }
            else if (string.IsNullOrEmpty(vehicles.Engine))
            {
                ModelState.AddModelError("", "Select Engine");
            }
            else if (string.IsNullOrEmpty(vehicles.Doors))
            {
                ModelState.AddModelError("", "Select Doors");
            }
            else if (string.IsNullOrEmpty(vehicles.Wheels))
            {
                ModelState.AddModelError("", "Select Wheels");
            }
            else if (string.IsNullOrEmpty(vehicles.BodyType))
            {
                ModelState.AddModelError("", "Select Body Type");
            }
            else if (string.IsNullOrEmpty(vehicles.Colour))
            {
                ModelState.AddModelError("", "Select Colour");
            }
        }    

        //public List<Vehicletype> LoadVehicleTypeList(VehiclesContext _modelContext)
        //{
        //    List<Vehicletype> vehicleType = new List<Vehicletype>();

        //    vehicleType = (from vehicle in _modelContext.Vehicletype where vehicle.IsActive.Equals('Y') select vehicle).ToList();
        //    vehicleType.Insert(0, new Vehicletype { VtId = 0, VehicletypeName = "Select" });

        //    return vehicleType;            
        //}

        public JsonResult GetMakeList(int VtId)
        {
            var _modelContext = new VehiclesContext();
            List<VehicleMake> vehicleMake = new List<VehicleMake>();

            vehicleMake = (from make in _modelContext.VehicleMake
                           join mapping in _modelContext.VehicleMakemodelMapping on make.VmakeId equals mapping.VmakeId
                           where mapping.VtId == VtId
                           select make).Distinct().ToList();
            vehicleMake.Insert(0, new VehicleMake { VmakeId = 0, VehiclemakeName = "Select" });
            return Json(new SelectList(vehicleMake, "VmakeId", "VehiclemakeName"));
        }

        public JsonResult GetModelList(int VmakeId)
        {
            var _modelContext = new VehiclesContext();
            List<VehicleModel> vehicleModel = new List<VehicleModel>();

            vehicleModel = (from model in _modelContext.VehicleModel
                            join mapping in _modelContext.VehicleMakemodelMapping on model.VmodelId equals mapping.VmodelId
                            where mapping.VmakeId == VmakeId
                            select model).ToList();
            vehicleModel.Insert(0, new VehicleModel { VmodelId = 0, VehiclemodelName = "Select" });
            return Json(new SelectList(vehicleModel, "VmodelId", "VehiclemodelName"));
        }

        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}