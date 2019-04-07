using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Models
{
    public class VehiclePropertiesModel
    {
        [Key]
        public decimal VpmId { get; set; }
        //[NotMapped]
        public decimal VpId { get; set; }
        //[NotMapped]
        public decimal VtId { get; set; }
        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string PropertyValue { get; set; }
    }

   


    
}
