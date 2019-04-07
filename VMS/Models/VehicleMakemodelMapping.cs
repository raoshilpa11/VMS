using VMS.Models;
using System;
using System.Collections.Generic;

namespace VMS.Models
{
    public partial class VehicleMakemodelMapping
    {
        public VehicleMakemodelMapping()
        {
            VehicleRecords = new HashSet<VehicleRecords>();
        }

        public decimal VmmpId { get; set; }
        public decimal VtId { get; set; }
        public decimal VmakeId { get; set; }
        public decimal VmodelId { get; set; }
        public char IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }

        public virtual VehicleMake Vmake { get; set; }
        public virtual VehicleModel Vmodel { get; set; }
        public virtual Vehicletype Vt { get; set; }
        public virtual ICollection<VehicleRecords> VehicleRecords { get; set; }
    }
}
