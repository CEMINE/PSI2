using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public class LogModel
    {
        [Key]
        public int LogID { get; set; }
        public DateTime OperationDate { get; set; }
        public string? Username { get; set; }
        public string? OperationDescription { get; set; }
    }
}
