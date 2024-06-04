using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public class MedicalCertificateModel : IDocument
    {
        private int _id;

        [Key]
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                DocID = _id;
            }
        }
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
        [NotMapped]
        public string DocType { get; set; } = "MedicalCertificate";
        [NotMapped]
        public int DocID { get; set; }
    }
}
