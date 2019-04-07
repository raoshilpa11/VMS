using CRUDADO.Models;
using CRUDADO.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CRUDADO.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
       
        //private readonly IVehiclesService _vehiclesService;
        //public HomeController(VehiclesContext modelContext)
        //{
        //    //Configuration = configuration;
        //    _modelContext = modelContext;
        //}

        //public HomeController(IVehiclesService vehiclesService)
        //{
        //    //Configuration = configuration;
        //    //_modelContext = modelContext;
        //    _vehiclesService = vehiclesService;
        //}


        public IActionResult Index()
        {
            var _modelContext = new VehiclesContext();
            //ViewBag.Vehicles = _modelContext.Vehicletype.Select(m => new SelectListItem { Text = m.VtId.ToString(), Value = m.VehicletypeName});
            //ViewBag.Vehicles = _modelContext.Vehicletype.Where( x => x.IsActive == 'Y').Select(m => new SelectListItem { Text = m.VtId.ToString() , Value = m.VehicletypeName }).ToList();
            List<Vehicle1> carList = new List<Vehicle1>();

            VehiclesService vs = new VehiclesService();
            carList = vs.FetchCars(1);

            return View(carList);

            //List<Teacher> teacherList = new List<Teacher>();

            //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    //SqlDataReader
            //    connection.Open();

            //    string sql = "Select * From Teacher";
            //    SqlCommand command = new SqlCommand(sql, connection);

            //    using (SqlDataReader dataReader = command.ExecuteReader())
            //    {
            //        while (dataReader.Read())
            //        {
            //            Teacher teacher = new Teacher();
            //            teacher.Id = Convert.ToInt32(dataReader["Id"]);
            //            teacher.Name = Convert.ToString(dataReader["Name"]);
            //            teacher.Skills = Convert.ToString(dataReader["Skills"]);
            //            teacher.TotalStudents = Convert.ToInt32(dataReader["TotalStudents"]);
            //            teacher.Salary = Convert.ToDecimal(dataReader["Salary"]);
            //            teacher.AddedOn = Convert.ToDateTime(dataReader["AddedOn"]);

            //            teacherList.Add(teacher);
            //        }
            //    }

            //    connection.Close();
            //}
            //return View(carList);
        }

        public IActionResult Create()
        {
            var _modelContext = new VehiclesContext();

            List<Vehicletype> vehicleType = new List<Vehicletype>();

            vehicleType = (from vehicle in _modelContext.Vehicletype where vehicle.IsActive.Equals('Y') select vehicle).ToList();
            vehicleType.Insert(0, new Vehicletype { VtId = 0, VehicletypeName = "Select" });
            ViewBag.ListOfVehicles = vehicleType;

            List<VehiclePropertiesMapping> vehicleProperties = new List<VehiclePropertiesMapping>();

            vehicleProperties = (from vehicle in _modelContext.VehiclePropertiesMapping where vehicle.IsActive.Equals('Y') && vehicle.VtId == 1 select vehicle).ToList();
            ViewBag.ListOfVehicleProperties = vehicleProperties;
            ViewData["vehicleProperties"] = vehicleProperties;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Vehicle1 vehicles, IFormCollection formCollection)
        {
            var _modelContext = new VehiclesContext();
            ////VehiclePropertiesMapping vpm = new VehiclePropertiesMapping();
            ////var VtId = 1;//vehicle.VtId;
            //ViewBag.VehiclePropertiesMapping = _modelContext.VehiclePropertiesMapping.Where(x => (x.VtId.Equals(VtId)) && x.IsActive.Equals('Y')).ToList();

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

            decimal VmakeId = Convert.ToDecimal(HttpContext.Request.Form["VmakeId"]);
            decimal VmodelId = Convert.ToDecimal(HttpContext.Request.Form["VmodelId"]);


            VehicleMakemodelMapping mapping = new VehicleMakemodelMapping();
            //vehicleMake = (from make in _modelContext.VehicleMakemodelMapping                           
            //               where make.VtId == VtId
            //               select make).ToList();
            mapping = (from mmm in _modelContext.VehicleMakemodelMapping
                       where mmm.VmakeId.Equals(VmakeId)
                       && mmm.VmodelId.Equals(VmodelId)
                       && mmm.IsActive.Equals('Y')
                       select mmm).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (mapping != null)
                {
                    var record = new VehicleRecords()
                    {
                        VmmpId = mapping.VmmpId
                    };
                    //_modelContext.Entry(record).State = EntityState.Added;
                    //_modelContext.SaveChanges();

                    _modelContext.VehicleRecords.Add(record);
                    _modelContext.SaveChanges();

                    decimal id = record.VrId;
                }
                //return View(vehicles);
                return RedirectToAction("Index");
            }
            else
            {
                List<Vehicletype> vehicleType = new List<Vehicletype>();

                vehicleType = (from vehicle in _modelContext.Vehicletype where vehicle.IsActive.Equals('Y') select vehicle).ToList();
                vehicleType.Insert(0, new Vehicletype { VtId = 0, VehicletypeName = "Select" });
                ViewBag.ListOfVehicles = vehicleType;

                return View(vehicles);
            }
        }

        public JsonResult GetMakeList(int VtId)
        {
            var _modelContext = new VehiclesContext();
            List<VehicleMake> vehicleMake = new List<VehicleMake>();
            //vehicleMake = (from make in _modelContext.VehicleMakemodelMapping                           
            //               where make.VtId == VtId
            //               select make).ToList();
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

        //[HttpPost]
        //public IActionResult Create(Teacher teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string sql = $"Insert Into Teacher (Name, Skills, TotalStudents, Salary) Values ('{teacher.Name}', '{teacher.Skills}','{teacher.TotalStudents}','{teacher.Salary}')";

        //            using (SqlCommand command = new SqlCommand(sql, connection))
        //            {
        //                command.CommandType = CommandType.Text;

        //                connection.Open();
        //                command.ExecuteNonQuery();
        //                connection.Close();
        //            }
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //        return View();
        //}

        public IActionResult Update(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            Teacher teacher = new Teacher();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From Teacher Where Id='{id}'";
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        teacher.Id = Convert.ToInt32(dataReader["Id"]);
                        teacher.Name = Convert.ToString(dataReader["Name"]);
                        teacher.Skills = Convert.ToString(dataReader["Skills"]);
                        teacher.TotalStudents = Convert.ToInt32(dataReader["TotalStudents"]);
                        teacher.Salary = Convert.ToDecimal(dataReader["Salary"]);
                        teacher.AddedOn = Convert.ToDateTime(dataReader["AddedOn"]);
                    }
                }

                connection.Close();
            }
            return View(teacher);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Teacher teacher)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Teacher SET Name='{teacher.Name}', Skills='{teacher.Skills}', TotalStudents='{teacher.TotalStudents}', Salary='{teacher.Salary}' Where Id='{teacher.Id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From Teacher Where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        ViewBag.Result = "Operation got error:" + ex.Message;
                    }
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }
    }
}