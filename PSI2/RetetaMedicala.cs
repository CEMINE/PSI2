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
    public partial class RetetaMedicala : Form
    {
        RetetaMedicalaModel reteta = new RetetaMedicalaModel();
        PatientModel patient;
        DoctorModel doctor;
        LogModel lm = new LogModel();
        private PatientServices _patientServices = new PatientServices();
        private DoctorServices _doctorServices = new DoctorServices();
        private RetetaMedicalaServices _retetaServices = new RetetaMedicalaServices();
        private Logger _logger = new Logger();
        public RetetaMedicala()
        {
            InitializeComponent();
        }

        private void RetetaMedicala_Load(object sender, EventArgs e)
        {
            patient = _patientServices.GetAllPatients().Where(x => x.PatientID == Meniu.Patient.PatientID).First();
            doctor = _doctorServices.GetAllDoctors().Where(x => x.DoctorID == Form1.User.UserID).First();
            txtAdresaUnitateSanitara.Text = doctor.OfficeAddress;
            txtUnitateSanitara.Text = doctor.UnitateSanitara;
            txtNumePacient.Text = patient.LastName;
            txtPrenumePacient.Text = patient.FirstName;
            txtVarsta.Text = (DateTime.Now.Year - Convert.ToDateTime(patient.DateOfBirth).Year).ToString();
            dtpDataNasterii.Value = Convert.ToDateTime(patient.DateOfBirth);
            txtAdresa.Text = patient.Address;

        }

        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtDiagnostic.Text))
            {
                MessageBox.Show("Nu ati completat campul diagnostic!");
                return;
            }
            if(String.IsNullOrEmpty(txtReteta.Text))
            {
                MessageBox.Show("Nu ati completat reteta!");
                return;
            }
            reteta.Diagnostic = txtDiagnostic.Text;
            reteta.Reteta = txtReteta.Text;
            reteta.Data = dtpData.Value;
            reteta.PatientID = patient.PatientID;
            reteta.DoctorID = doctor.DoctorID;
            if(await _retetaServices.AddRetetaMedicala(reteta))
            {
                MessageBox.Show("Reteta a fost salvata!");
                lm.OperationDate = DateTime.Now;
                lm.Username = doctor.Username;
                lm.OperationDescription = $"Utilizatorul a adaugat o reteta medicala pentru pacientul {patient.LastName} {patient.FirstName}.";
                await _logger.Log(lm);
                this.Hide();
                Meniu m = new Meniu();
                m.Show();
            }
            else
            {
                MessageBox.Show("A aparut o eroare la adaugarea retetei!");
            }
        }

        public void IncarcaDate()
        {
            RetetaMedicalaModel rm = _retetaServices.GetAllReteteMedicala().Where(x => x.ID == Meniu.DocumentVizualizare.ID).First();
            if(rm != null)
            {
                txtDiagnostic.Text = rm.Diagnostic;
                txtReteta.Text = rm.Reteta;
                dtpData.Value = Convert.ToDateTime(rm.Data);
                txtNr.Text = rm.ID.ToString();
            }
        }
    }
}
