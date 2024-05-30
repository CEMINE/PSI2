using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PSI2.Models
{
    public class PatientModel
    {
        [Key]
        public int PatientID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? CNP { get; set; }
        public string? Serie { get; set; }
        public string? Numar { get; set; }
        public string? Cetatenie { get; set; }
        public string? StareCivila { get; set; }
    }

}
