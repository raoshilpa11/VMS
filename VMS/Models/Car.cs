using System.ComponentModel.DataAnnotations;

namespace VMS.Models
{
    public class Car
    {
        [Key]
        public decimal VPM { get; set; }
        public string Value { get; set; }
        //[NotMapped]
        //public string Engine { get; set; }
        //[NotMapped]
        //public string Wheels { get; set; }
        //[NotMapped]
        //public string Doors { get; set; }
        //[NotMapped]
        //public string BodyType { get; set; }
        //[NotMapped]
        //public string Colour { get; set; }
    }
}
