using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public class RetetaMedicalaModel : IDocument
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

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public string? Diagnostic { get; set; }

        public string? Reteta { get; set; }

        public DateTime Data { get; set; }

        public PatientModel? Patient { get; set; }
        public DoctorModel? Doctor { get; set; }

        [NotMapped]
        public string DocType { get; set; } = "RetetaMedicala";

        [NotMapped]
        public int DocID { get; set; }
    }
}
