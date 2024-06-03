using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public class MedicalCertificateModel
    {
        [Key]
        public int ID { get; set; }
        public string? Adresa { get; set; }
        public string? Observatii { get; set; }
        public string? Recomandare { get; set; }
        public string? MotivulEliberarii { get; set; }
        public DateTime DataEliberarii { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
    }
}
