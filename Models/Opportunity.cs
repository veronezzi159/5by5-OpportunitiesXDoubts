using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Models
{
    public class Opportunity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string OutbreakLevel { get; set; }
        public Int64  HoursQtd { get; set; }
        public Int64 ErrorsQtd { get; set; }
        public Int64 LearnLevel { get; set; }
        public Int64 HoursSleep { get; set; }
        public int HoursOff { get; set; }


    }
}
