using System;
using System.Collections.Generic;

namespace VMS.Models
{
    public partial class VehicleRecordsProperties
    {
        public decimal VrpId { get; set; }
        public decimal VrId { get; set; }
        public decimal VpmId { get; set; }
        public string Value { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }

        public virtual VehiclePropertiesMapping Vpm { get; set; }
        public virtual VehicleRecords Vr { get; set; }
    }
}
