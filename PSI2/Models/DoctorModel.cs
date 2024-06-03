using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public  class DoctorModel
    {
        [Key]
        public int DoctorID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string? Specialization { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? OfficeAddress { get; set; }
        public string? UnitateSanitara { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

    }
}
