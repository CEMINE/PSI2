using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI2.Models;
using PSI2.Services;

namespace PSI2
{
    public partial class BiletTrimitere : Form
    {
        PatientServices _patientServices = new PatientServices();
        DoctorServices _doctorServices = new DoctorServices();
        BiletTrimitereServices _btServices = new BiletTrimitereServices();
        Logger _logger = new Logger();
        LogModel lm = new LogModel();
        PatientModel patient;
        DoctorModel doctor;
        BiletTrimitereModel bt = new BiletTrimitereModel();
        string nivelPrioritate;

        public BiletTrimitere()
        {
            InitializeComponent();
        }

        private void BiletTrimitere_Load(object sender, EventArgs e)
        {
            patient = _patientServices.GetAllPatients().Where(x => x.PatientID == Meniu.Patient.PatientID).First();
            doctor = _doctorServices.GetAllDoctors().Where(y => y.DoctorID == Form1.User.UserID).First();

            txtUnitateMedicala.Text = doctor.UnitateSanitara;
            txtAdresaUnitateMedicala.Text = doctor.OfficeAddress;
            txtNume.Text = patient.LastName;
            txtPrenume.Text = patient.FirstName;
            txtAdresaPacient.Text = patient.Address;
            txtCNP.Text = patient.CNP;
            txtCetatenie.Text = patient.Cetatenie;


        }

        private void rbtUrgenta_CheckedChanged(object sender, EventArgs e)
        {
            nivelPrioritate = "urgenta";
        }

        private void rbtCurente_CheckedChanged(object sender, EventArgs e)
        {
            nivelPrioritate = "curente";
        }

        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiagnostic.Text))
            {
                MessageBox.Show("Completati diagnostic!");
                return;
            }
            if (String.IsNullOrEmpty(txtCodDiagnostic.Text))
            {
                MessageBox.Show("Completati cod diagnostic!");
                return;
            }
            if (String.IsNullOrEmpty(txtMotiv.Text))
            {
                MessageBox.Show("Nu ati completat motivul trimiterii!");
                return;
            }
            if (String.IsNullOrEmpty(txtTratamenteEfectuate.Text))
            {
                MessageBox.Show("Nu ati completat campul investigatii si tratamente efectuate!");
                return;
            }
            if (String.IsNullOrEmpty(txtNrConsultatii.Text))
            {
                MessageBox.Show("Nu ati completat numarul de consultatii acordate!");
                return;
            }
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Nu ati completat motivul pentru care nu a fost necesare internarea!");
                return;
            }
            if (String.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Nu ati completat seria!");
                return;
            }
            if (String.IsNullOrEmpty(nivelPrioritate))
            {
                MessageBox.Show("Nu ati selectat nivelul de prioritate!");
                return;
            }

            bt.Diagnostic = txtDiagnostic.Text;
            bt.CodDiagnostic = txtCodDiagnostic.Text;
            bt.MotivulTrimiterii = txtMotiv.Text;
            bt.InvestigatiiEfectuate = txtTratamenteEfectuate.Text;
            bt.NrConsultatiiAcordate = Convert.ToInt32(txtNrConsultatii.Text);
            bt.DataTrimiterii = dtpDataTrimiterii.Value;
            bt.DataPrezentarePacient = dateTimePicker2.Value;
            bt.Serie = txtSerie.Text;
            bt.PatientID = patient.PatientID;
            bt.DoctorID = doctor.DoctorID;
            bt.NivelPrioritate = nivelPrioritate;
            bt.AlteDiagnosticeCunoscute = txtAlteDiagnostice.Text;
            bt.MotivRecomandareDomiciliu = richTextBox1.Text;

            if (await _btServices.AddBiletTrimitere(bt))
            {
                MessageBox.Show("Biletul de trimitere a fost salvat!");
                lm.OperationDate = DateTime.Now;
                lm.Username = _doctorServices.GetAllDoctors().Where(x => x.DoctorID == Form1.User.UserID).First().Username;
                lm.OperationDescription = $"Utilizatorul a adaugat un bilet de trimitere pentru pacientul {patient.LastName} {patient.FirstName}";
                await _logger.Log(lm);
                this.Hide();
                Meniu m = new Meniu();
                m.Show();
                return;
            }
            else
            {
                MessageBox.Show("A aparut o eroare la salvarea biletului de trimitere!");
            }

        }

        public void IncarcareDate()
        {
            int docID = Meniu.DocumentVizualizare.ID;
            BiletTrimitereModel btVizualizare = new BiletTrimitereModel();
            btVizualizare = _btServices.GetAllBileteTrimitere().Where(x => x.ID == docID).First();
            txtDiagnostic.Text = btVizualizare.Diagnostic;
            txtCodDiagnostic.Text = btVizualizare.CodDiagnostic;
            txtAlteDiagnostice.Text = btVizualizare.AlteDiagnosticeCunoscute;
            txtMotiv.Text = btVizualizare.MotivulTrimiterii;
            txtTratamenteEfectuate.Text = btVizualizare.InvestigatiiEfectuate;
            txtNrConsultatii.Text = btVizualizare.NrConsultatiiAcordate.ToString();
            dtpDataTrimiterii.Value = btVizualizare.DataTrimiterii;
            richTextBox1.Text = btVizualizare.MotivRecomandareDomiciliu;
            dateTimePicker2.Value = btVizualizare.DataPrezentarePacient;
            txtSerie.Text = btVizualizare.Serie;
            txtNr.Text = btVizualizare.ID.ToString();
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Meniu meniu = new Meniu();
            meniu.Show();
        }
    }
}
