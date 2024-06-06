using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Models
{
    public class FisaConsultatiiModel :IDocument
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

        public string? SchimbariDomiciliu { get; set; }

        public string? SchimbariLocMunca { get; set; }

        public string? AntecedenteHeredo { get; set; }

        public string? AntecedentePersonale { get; set; }

        public string? ConditiiMunca { get; set; }

        public DateTime DataInvestigatie { get; set; }

        public string? LocInvestigatie { get; set; }

        public string? SimptomeInvestigatie { get; set; }

        public string? DiagnosticInvestigatie { get; set; }

        public string? CodInvestigatie { get; set; }

        public string? RecomandareInvestigatie { get; set; }

        public PatientModel? Patient { get; set; }
        public DoctorModel? Doctor { get; set; }
        [NotMapped]
        public string DocType { get; set; } = "FisaConsultatii";
        [NotMapped]
        public int DocID { get; set; }
    }
}
