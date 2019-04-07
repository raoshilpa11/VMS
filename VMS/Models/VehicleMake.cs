using System;
using System.Collections.Generic;

namespace VMS.Models
{
    public partial class VehicleMake
    {
        public VehicleMake()
        {
            VehicleMakemodelMapping = new HashSet<VehicleMakemodelMapping>();
        }

        public decimal VmakeId { get; set; }
        public string VehiclemakeName { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<VehicleMakemodelMapping> VehicleMakemodelMapping { get; set; }
    }
}
