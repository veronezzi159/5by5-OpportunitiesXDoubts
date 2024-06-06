using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Doubt
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DoubtDate { get; set; }
    }
}
