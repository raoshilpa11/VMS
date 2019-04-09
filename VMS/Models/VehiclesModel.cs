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
        [Range(0, 4, ErrorMessage = "Can only be between 0 .. 4")]
        [StringLength(1, ErrorMessage = "Max 1 digit")]
        public string Wheels { get; set; }
        [NotMapped]
        [Range(0, 6, ErrorMessage = "Can only be between 0 .. 6")]
        [StringLength(1, ErrorMessage = "Max 1 digit")]
        public string Doors { get; set; }
        [NotMapped]
        public string BodyType { get; set; }
        [NotMapped]
        public string Colour { get; set; }
    }

}
