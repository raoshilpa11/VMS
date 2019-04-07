using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VMS.Models
{
    public partial class VehicleRecords
    {
        public VehicleRecords()
        {
            VehicleRecordsProperties = new HashSet<VehicleRecordsProperties>();
        }
        [Key]
        public decimal VrId { get; set; }
        public decimal VmmpId { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }

        public virtual VehicleMakemodelMapping Vmmp { get; set; }
        public virtual ICollection<VehicleRecordsProperties> VehicleRecordsProperties { get; set; }
    }
}
