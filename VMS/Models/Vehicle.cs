using System;
using System.Collections.Generic;

namespace VMS.Models
{
    public partial class Vehicle
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Wheels { get; set; }
        public string Doors { get; set; }
        public string Bodytype { get; set; }
        public string Colours { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }
    }
}
