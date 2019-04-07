using System;
using System.Collections.Generic;

namespace VMS.Models
{
    public partial class VehiclePropertiesMapping
    {
        public VehiclePropertiesMapping()
        {
            VehicleRecordsProperties = new HashSet<VehicleRecordsProperties>();
        }

        public decimal VpmId { get; set; }
        public decimal VtId { get; set; }
        public decimal VpId { get; set; }
        public char IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }

        public virtual VehicleProperties Vp { get; set; }
        public virtual Vehicletype Vt { get; set; }
        public virtual ICollection<VehicleRecordsProperties> VehicleRecordsProperties { get; set; }
    }
}
