using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static PSI2.Meniu;

namespace PSI2.Models
{
    public class BiletTrimitereModel : IDocument
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

        public string? Serie { get; set; }

        public string? NivelPrioritate { get; set; }

        public string? Diagnostic { get; set; }

        public string? CodDiagnostic { get; set; }

        public string? AlteDiagnosticeCunoscute { get; set; }

        public string? MotivulTrimiterii { get; set; }

        public string? InvestigatiiEfectuate { get; set; }

        public int NrConsultatiiAcordate { get; set; }

        public DateTime DataTrimiterii { get; set; }
        public DateTime DataPrezentarePacient { get; set; }

        public string? MotivRecomandareDomiciliu { get; set; }

        public virtual PatientModel? Patient { get; set; }
        public virtual DoctorModel? Doctor { get; set; }
        [NotMapped]
        public string DocType { get; set; } = "BiletTrimitere";
        [NotMapped]
        public int DocID { get; set; }
    }
}
