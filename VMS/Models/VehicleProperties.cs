using System;
using System.Collections.Generic;

namespace VMS.Models
{
    public partial class VehicleProperties
    {
        public VehicleProperties()
        {
            VehiclePropertiesMapping = new HashSet<VehiclePropertiesMapping>();
        }

        public decimal VpId { get; set; }
        public string Property { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<VehiclePropertiesMapping> VehiclePropertiesMapping { get; set; }
    }
}
