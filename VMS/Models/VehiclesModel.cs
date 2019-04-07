using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Models
{
    public class VehiclesModel
    {
        [Key]
        public decimal VRId { get; set; }
        public decimal VMMPId { get; set; }
        public decimal VtId { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public decimal VmakeId { get; set; }
        public string Model { get; set; }
        public decimal VmodelId { get; set; }
        [NotMapped]
        public char Is_Active { get; set; }
        [NotMapped]
        public string Created_By { get; set; }
        [NotMapped]
        public DateTime Created_Date { get; set; }
        [NotMapped]
        public string Modified_By { get; set; }
        [NotMapped]
        public DateTime Modified_Date { get; set; }
        [NotMapped]
        public string Engine { get; set; }
        [NotMapped]
        public string Wheels { get; set; }
        [NotMapped]
        public string Doors { get; set; }
        [NotMapped]
        public string BodyType { get; set; }
        [NotMapped]
        public string Colour { get; set; }
    }

}
