using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public class ConcediuMedicalModel : IDocument
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

        public int Luna { get; set; }
        public int Anul { get; set; }
        public string? CodIndemnizatie { get; set; }
        public string? NrInregistrare { get; set; }
        public DateTime DataAcordarii { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public string? CodDiagnostic { get; set; }
        public string? TipBoala { get; set; }
        public string? NrConventie { get; set; }
        public int NrAngajati { get; set; }
        public string? CAS { get; set; }
        public string? CUI { get; set; }
        public string? CASEmitenta { get; set; }
        public string? Platitor { get; set; }
        public string? SediuPlatitor { get; set; }
        public string? CUIPlatitor { get; set; }
        public string? Serie { get; set; }
        public string? TipAsigurat { get; set; }
        public string? ProcentPlata { get; set; }
        public string? IndemnizatieAngajator { get; set; }
        public string? IndemnizatieFNUASS { get; set; }
        public string? IndemnizatieFont { get; set; }
        public DateTime DataPrimirii { get; set; }

        public virtual PatientModel? Patient { get; set; }
        public virtual DoctorModel? Doctor { get; set; }

        [NotMapped]
        public int DocID {get;set;}
        [NotMapped]
        public string DocType { get; set; } = "ConcediuMedical";
    }
}
