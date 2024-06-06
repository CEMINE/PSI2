using Microsoft.IdentityModel.Tokens;
using PSI2.Models;
using PSI2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI2
{
    public partial class FisaConsultatii : Form
    {
        PatientModel patient;
        DoctorModel doctor;
        LogModel lm = new LogModel();
        FisaConsultatiiModel fc = new FisaConsultatiiModel();
        private PatientServices _patientServices = new PatientServices();
        private DoctorServices _doctorServices = new DoctorServices();
        private FisaConsultatiiServices _fcServices = new FisaConsultatiiServices();
        private Logger _logger = new Logger();
        char sex;

        public FisaConsultatii()
        {
            InitializeComponent();
        }

        private void FisaConsultatii_Load(object sender, EventArgs e)
        {
            patient = _patientServices.GetAllPatients().Where(x => x.PatientID == Meniu.Patient.PatientID).First();
            doctor = _doctorServices.GetAllDoctors().Where(y => y.DoctorID == Form1.User.UserID).First();
            if (patient != null && doctor != null)
            {
                txtUnitateSanitara.Text = doctor.UnitateSanitara;
                txtAdresa.Text = doctor.OfficeAddress;
                txtCNP.Text = patient.CNP;
                txtNume.Text = patient.LastName;
                txtPrenume.Text = patient.FirstName;
                if (patient.Gender == 'M')
                {
                    sex = 'M';
                    rbtF.Checked = false;
                    rbtM.Checked = true;
                }
                if (patient.Gender == 'F')
                {
                    sex = 'F';
                    rbtF.Checked = true;
                    rbtM.Checked = false;
                }
                dtpDataNasterii.Value = Convert.ToDateTime(patient.DateOfBirth);
                txtAdresa.Text = patient.Address;

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtM_CheckedChanged(object sender, EventArgs e)
        {
            sex = 'M';
        }

        private void rbtF_CheckedChanged(object sender, EventArgs e)
        {
            sex = 'F';
        }

        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSchimbareDomiciliu.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtScimbareLocMunca.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtConditiiMunca.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtLocConsultatie.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtSimptome.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtDiagnostic.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtCodDiagnostic.Text))
            {
                MessageBox.Show("Test");
                return;
            }
            if (String.IsNullOrEmpty(txtRecomandari.Text))
            {
                MessageBox.Show("Test");
                return;
            }

            if (patient != null && doctor != null)
            {
                fc.PatientID = patient.PatientID;
                fc.DoctorID = doctor.DoctorID;
            }
            fc.SchimbariDomiciliu = txtSchimbareDomiciliu.Text;
            fc.SchimbariLocMunca = txtScimbareLocMunca.Text;
            fc.AntecedenteHeredo = txtAntecedenteHeredo.Text;
            fc.AntecedentePersonale = txtAntecedentePersonale.Text;
            fc.ConditiiMunca = txtConditiiMunca.Text;
            fc.DataInvestigatie = dtpData.Value;
            fc.LocInvestigatie = txtLocConsultatie.Text;
            fc.SimptomeInvestigatie = txtSimptome.Text;
            fc.DiagnosticInvestigatie = txtDiagnostic.Text;
            fc.CodInvestigatie = txtCodDiagnostic.Text;
            fc.RecomandareInvestigatie = txtRecomandari.Text;

            if (await _fcServices.AddFisaConsultatii(fc))
            {
                MessageBox.Show("Fisa de consultatii a fost salvata cu succes!");
                lm.OperationDate = DateTime.Now;
                lm.Username = doctor.Username;
                lm.OperationDescription = $"Utilizatorul a adaugat o fisa de consultatii pentru pacientul {patient.LastName} {patient.FirstName}";
                await _logger.Log(lm);
                this.Hide();
                Meniu m = new Meniu();
                m.Show();
            }
            else
            {
                MessageBox.Show("A aparut o eroare la salvarea fisei de consultatii!");
            }
        }

        public void IncarcaDate()
        {
            FisaConsultatiiModel fcm = _fcServices.GetAllFiseConsultatii().Where(x => x.DocID == Meniu.DocumentVizualizare.ID).First();
            txtSchimbareDomiciliu.Text = fcm.SchimbariDomiciliu;
            txtScimbareLocMunca.Text = fcm.SchimbariLocMunca;
            txtAntecedenteHeredo.Text = fcm.AntecedenteHeredo;
            txtAntecedentePersonale.Text = fcm.AntecedentePersonale;
            txtConditiiMunca.Text = fcm.ConditiiMunca;
            dtpData.Value = fcm.DataInvestigatie;
            txtLocConsultatie.Text = fcm.LocInvestigatie;
            txtSimptome.Text = fcm.SimptomeInvestigatie;
            txtDiagnostic.Text = fcm.DiagnosticInvestigatie;
            txtCodDiagnostic.Text = fcm.CodInvestigatie;
            txtRecomandari.Text = fcm.RecomandareInvestigatie;
            txtNr.Text = fcm.ID.ToString();
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Meniu meniu = new Meniu();
            meniu.Show();
        }
        public bool IsNumber(string t)
        {
            bool isNumber = double.TryParse(t, out double result);
            return isNumber;
        }
    }
}
