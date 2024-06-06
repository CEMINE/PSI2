using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI2.Services;
using PSI2.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace PSI2  
{
    public partial class ConcediuMedical : Form
    {
        PatientServices _patientServices = new PatientServices();
        DoctorServices _doctorServices = new DoctorServices();
        ConcediuMedicalServices _concediuMedicalServices = new ConcediuMedicalServices();
        string tipAsigurat;
        string procentPlata;
        string tipBoala;
        PatientModel patient;
        DoctorModel doctor;
        LogModel lm = new LogModel();
        Logger _logger = new Logger();
        public ConcediuMedical()
        {
            InitializeComponent();
        }

        private void ConcediuMedical_Load(object sender, EventArgs e)
        {
            patient = _patientServices.GetAllPatients().Where(x => x.PatientID == Meniu.Patient.PatientID).First();
            doctor = _doctorServices.GetAllDoctors().Where(y => y.DoctorID == Form1.User.UserID).First();
            txtNumePacient.Text = patient.LastName + " " + patient.FirstName;
            txtCNP.Text = patient.CNP;
            txtAdresaPacient.Text = patient.Address;
            txtUnitateSanitara.Text = doctor.UnitateSanitara;
            txtNumeDoctor.Text = doctor.LastName + " " + doctor.FirstName;
        }

        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            ConcediuMedicalModel cm = new ConcediuMedicalModel();
            if (String.IsNullOrEmpty(tipBoala))
            {
                MessageBox.Show("Nu ati selectat tipul bolii!");
                return;
            }
            if (String.IsNullOrEmpty(procentPlata))
            {
                MessageBox.Show("Nu ati selectat procentul de plata!");
                return;
            }
            if (String.IsNullOrEmpty(tipAsigurat))
            {
                MessageBox.Show("Nu ati selectat tipul asigurarii pacientului!(asigurat/somer)");
                return;
            }
            if (String.IsNullOrEmpty(txtNrInreg.Text))
            {
                MessageBox.Show("Nu ati completat campul nr. inregistrare!");
                return;
            }
            if (String.IsNullOrEmpty(txtCodDiagnostic.Text))
            {
                MessageBox.Show("Nu ati completat codul diagnostic!");
                return;
            }
            if (String.IsNullOrEmpty(txtNrConventie.Text))
            {
                MessageBox.Show("Nu ati completat numarul de conventie!");
                return;
            }
            if (String.IsNullOrEmpty(txtCAS.Text))
            {
                MessageBox.Show("Nu ati completat campul CAS!");
                return;
            }
            if (String.IsNullOrEmpty(txtCUI.Text))
            {
                MessageBox.Show("Nu ati completat campul CUI!");
                return;
            }
            if (String.IsNullOrEmpty(txtCASEmitent.Text))
            {
                MessageBox.Show("Nu ati completat campul CAS emitenta!");
                return;
            }
            if (String.IsNullOrEmpty(txtPlatitor.Text))
            {
                MessageBox.Show("Nu ati completat campul platitor!");
                return;
            }
            if (String.IsNullOrEmpty(txtSediu.Text))
            {
                MessageBox.Show("Nu ati completat campul sediu platitor!");
                return;
            }
            if (String.IsNullOrEmpty(txtCUIPlatitor.Text))
            {
                MessageBox.Show("Nu ati completat campul CUI platitor!");
                return;
            }
            if (numNrAngajati.Value <= 0)
            {
                MessageBox.Show("Nu ati completat campul numar angajati!");
                return;
            }
            if (String.IsNullOrEmpty(txtIndemnizatieAngajator.Text))
            {
                MessageBox.Show("Nu ati completat campul indemnizatie suportata de angajator!");
                return;
            }
            if (String.IsNullOrEmpty(txtIndemnizatieFNUASS.Text))
            {
                MessageBox.Show("Nu ati completat campul indemnizatie suportata din bugetul FNUASS!");
                return;
            }
            if (String.IsNullOrEmpty(txtIndemnizatieFond.Text))
            {
                MessageBox.Show("Nu ati completat campul indemnizatie suportata din fondul de asigurare!");
                return;
            }
            if (IsNumber(txtIndemnizatieAngajator.Text))
            {
                MessageBox.Show("Indemnizatia suportata de catre angajator trebuie sa fie un numar!");
                return;
            }
            if (IsNumber(txtIndemnizatieFNUASS.Text))
            {
                MessageBox.Show("Indemnizatia suportata de catre FNUASS trebuie sa fie un numar!");
                return;
            }
            if (IsNumber(txtIndemnizatieFond.Text))
            {
                MessageBox.Show("Indemnizatia suportata de catre fond trebuie sa fie un numar!");
                return;
            }


            cm.Luna = Convert.ToInt32(numLuna.Value);
            cm.Anul = Convert.ToInt32(numAnul.Value);
            cm.CodIndemnizatie = numCodIndemnizatie.Value.ToString();
            cm.Serie = txtSerie.Text;
            cm.CodDiagnostic = txtCodDiagnostic.Text;
            cm.NrConventie = txtNrConventie.Text;
            cm.NrInregistrare = txtNrInreg.Text;
            cm.DataAcordarii = dtpDataAcordarii.Value;
            cm.DataInceput = dtpDataInceput.Value;
            cm.DataSfarsit = dtpDataSfarsit.Value;
            cm.TipBoala = tipBoala;
            cm.CAS = txtCAS.Text;
            cm.CUI = txtCUI.Text;
            cm.CASEmitenta = txtCASEmitent.Text;
            cm.Platitor = txtPlatitor.Text;
            cm.SediuPlatitor = txtSediu.Text;
            cm.CUIPlatitor = txtCUIPlatitor.Text;
            cm.NrAngajati = Convert.ToInt32(numNrAngajati.Value);
            cm.TipAsigurat = tipAsigurat;
            cm.ProcentPlata = procentPlata;
            cm.IndemnizatieAngajator = txtIndemnizatieAngajator.Text;
            cm.IndemnizatieFNUASS = txtIndemnizatieFNUASS.Text;
            cm.IndemnizatieFont = txtIndemnizatieFond.Text;
            cm.DataPrimirii = dtpDataPrimirii.Value;
            cm.PatientID = patient.PatientID;
            cm.DoctorID = doctor.DoctorID;
            if (await _concediuMedicalServices.AddConcediuMedical(cm))
            {
                MessageBox.Show("Concediul medical a fost salvat cu succes!");
                lm.Username = doctor.Username;
                lm.OperationDate = DateTime.Now;
                lm.OperationDescription = $"Utilizatorul a adaugat concediul medical pentru {patient.LastName} {patient.FirstName}";
            }
            else
            {
                MessageBox.Show("A aparut o eroare la adaugarea concediului medical!");
            }


        }

        private void rbtAcut_CheckedChanged(object sender, EventArgs e)
        {
            tipBoala = "acut";
        }

        private void rbtSemiacut_CheckedChanged(object sender, EventArgs e)
        {
            tipBoala = "semiacut";
        }

        private void rbtCronic_CheckedChanged(object sender, EventArgs e)
        {
            tipBoala = "cronic";
        }

        private void rbtAsigurat_CheckedChanged(object sender, EventArgs e)
        {
            tipAsigurat = "asigurat";
        }

        private void rbtSomer_CheckedChanged(object sender, EventArgs e)
        {
            tipAsigurat = "somer";
        }

        private void rbt75_CheckedChanged(object sender, EventArgs e)
        {
            procentPlata = "75";
        }

        private void rbt80_CheckedChanged(object sender, EventArgs e)
        {
            procentPlata = "80";
        }

        private void rbt85_CheckedChanged(object sender, EventArgs e)
        {
            procentPlata = "85";
        }

        private void rbt100_CheckedChanged(object sender, EventArgs e)
        {
            procentPlata = "100";
        }

        private void rbtPreventie_CheckedChanged(object sender, EventArgs e)
        {
            procentPlata = "preventie";
        }

        public void IncarcaDate()
        {
            ConcediuMedicalModel cm = _concediuMedicalServices.GetAllConcediiMedicale().Where(x => x.ID == Meniu.DocumentVizualizare.ID).First();
            numLuna.Value = cm.Luna;
            numAnul.Value = cm.Anul;
            numCodIndemnizatie.Value = Convert.ToDecimal(cm.CodIndemnizatie);
            txtSerie.Text = cm.Serie;
            txtCodDiagnostic.Text = cm.CodDiagnostic;
            txtNrConventie.Text = cm.NrConventie;
            txtNrInreg.Text = cm.NrInregistrare;
            dtpDataAcordarii.Value = cm.DataAcordarii;
            dtpDataInceput.Value = cm.DataInceput;
            dtpDataSfarsit.Value = cm.DataSfarsit;
            if (cm.TipBoala == "acut")
            {
                rbtCronic.Checked = false;
                rbtSemiacut.Checked = false;
                rbtAcut.Checked = true;
                tipBoala = "acut";
            }
            if (cm.TipBoala == "semiacut")
            {
                rbtCronic.Checked = false;
                rbtSemiacut.Checked = true;
                rbtAcut.Checked = false;
                tipBoala = "semiacut";
            }
            if (cm.TipBoala == "cronic")
            {
                rbtCronic.Checked = true;
                rbtSemiacut.Checked = false;
                rbtAcut.Checked = false;
                tipBoala = "cronic";
            }
            txtCAS.Text = cm.CAS;
            txtCUI.Text = cm.CUI;
            txtCASEmitent.Text = cm.CASEmitenta;
            txtPlatitor.Text = cm.Platitor;
            txtSediu.Text = cm.SediuPlatitor;
            txtCUIPlatitor.Text = cm.CUIPlatitor;
            numNrAngajati.Value = cm.NrAngajati;
            if (cm.TipAsigurat == "asigurat")
            {
                rbtSomer.Checked = false;
                rbtAsigurat.Checked = true;
                tipAsigurat = "asigurat";
            }
            if (cm.TipAsigurat == "somer")
            {
                rbtSomer.Checked = true;
                rbtAsigurat.Checked = false;
                tipAsigurat = "somer";
            }
            if (cm.ProcentPlata == "75")
            {
                rbt75.Checked = true;
                rbt80.Checked = false;
                rbt85.Checked = false;
                rbt100.Checked = false;
                rbtPreventie.Checked = false;
                procentPlata = "75";

            }
            if (cm.ProcentPlata == "80")
            {
                rbt75.Checked = false;
                rbt80.Checked = true;
                rbt85.Checked = false;
                rbt100.Checked = false;
                rbtPreventie.Checked = false;
                procentPlata = "80";
            }
            if (cm.ProcentPlata == "85")
            {
                rbt75.Checked = false;
                rbt80.Checked = false;
                rbt85.Checked = true;
                rbt100.Checked = false;
                rbtPreventie.Checked = false;
                procentPlata = "85";
            }
            if (cm.ProcentPlata == "100")
            {
                rbt75.Checked = false;
                rbt80.Checked = false;
                rbt85.Checked = false;
                rbt100.Checked = true;
                rbtPreventie.Checked = false;
                procentPlata = "100";
            }
            if (cm.ProcentPlata == "preventiv")
            {
                rbt75.Checked = false;
                rbt80.Checked = false;
                rbt85.Checked = false;
                rbt100.Checked = false;
                rbtPreventie.Checked = true;
                procentPlata = "preventiv";
            }
            txtIndemnizatieAngajator.Text = cm.IndemnizatieAngajator.ToString();
            txtIndemnizatieFNUASS.Text = cm.IndemnizatieFNUASS.ToString();
            txtIndemnizatieFond.Text = cm.IndemnizatieFont.ToString();
            dtpDataPrimirii.Value = cm.DataPrimirii;
        }

        public bool IsNumber(string t)
        {
            bool isNumber = double.TryParse(t, out double result);
            return isNumber;
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Meniu meniu = new Meniu();
            meniu.Show();
        }
    }
}
