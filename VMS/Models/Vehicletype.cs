using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VMS.Models
{
    public partial class Vehicletype
    {
        public Vehicletype()
        {
            VehicleMakemodelMapping = new HashSet<VehicleMakemodelMapping>();
            VehiclePropertiesMapping = new HashSet<VehiclePropertiesMapping>();
        }
        [Key]
        public decimal VtId { get; set; }
        public string VehicletypeName { get; set; }
        public string Description { get; set; }
        public char IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<VehicleMakemodelMapping> VehicleMakemodelMapping { get; set; }
        public virtual ICollection<VehiclePropertiesMapping> VehiclePropertiesMapping { get; set; }
    }
}
