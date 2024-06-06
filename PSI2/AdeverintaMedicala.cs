using Microsoft.VisualBasic.ApplicationServices;
using PSI2.Models;
using PSI2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI2
{
    public partial class AdeverintaMedicala : Form
    {
        private PatientServices _patientServices = new PatientServices();
        private DoctorServices _doctorServices = new DoctorServices();
        private MedicalCertificateServices _medicalCertificateServices = new MedicalCertificateServices();
        private Logger _logger = new Logger();
        LogModel lm = new LogModel();
        MedicalCertificateModel adv = new MedicalCertificateModel();
        int patientId;
        int doctorId;
        PatientModel patient;
        DoctorModel doctor;
        string boala, recomandare, motiv;
        DateTime? dataEliberare;
        public AdeverintaMedicala()
        {
            InitializeComponent();

        }


        private void AdeverintaMedicala_Load(object sender, EventArgs e)
        {
            doctorId = Form1.User.UserID;
            patientId = Meniu.Patient.PatientID;
            patient = _patientServices.GetAllPatients().Where(x => x.PatientID == patientId).First();
            doctor = _doctorServices.GetAllDoctors().Where(y => y.DoctorID == doctorId).First();
            if (patient != null && doctor != null)
            {
                txtUnitateSanitara.Text = doctor.UnitateSanitara;
                txtAdresaCabinet.Text = doctor.OfficeAddress;
                txtNume.Text = patient.LastName + " " + patient.FirstName;
                if (patient.Gender == 'M')
                {
                    rbtF.Checked = false;
                    rbtM.Checked = true;
                }
                else
                {
                    rbtM.Checked = false;
                    rbtF.Checked = true;
                }
                txtCNP.Text = patient.CNP;
                dtpDataNasterePacient.Value = Convert.ToDateTime(patient.DateOfBirth);
                txtAdresaPacient.Text = patient.Address;

            }
        }
        public async void test()
        {
            adv.DoctorID = 1;
            adv.PatientID = 1;
            adv.Observatii = "test";
            adv.Recomandare = "test";
            adv.Adresa = "test";
            adv.MotivulEliberarii = "test";
            adv.DataEliberarii = DateTime.Now;
            await _medicalCertificateServices.AddMedicalCertificate(adv);
        }

        private async void btnCreeazaAdeverinta_Click(object sender, EventArgs e)
        {

            recomandare = txtRecomandare.Text;
            if (String.IsNullOrEmpty(recomandare))
            {
                MessageBox.Show("Nu ati introdus o recomandare!");
                return;
            }
            boala = txtBoala.Text;
            if (String.IsNullOrEmpty(boala))
            {
                MessageBox.Show("Nu ati introdus boala de care sufera pacientul!");
                return;
            }
            motiv = txtMotivEliberare.Text;
            if (String.IsNullOrEmpty(motiv))
            {
                MessageBox.Show("Nu ati introdus motivul eliberarii!");
                return;
            }
            dataEliberare = dtpDataEliberarii.Value;
            if (!dataEliberare.HasValue)
            {
                MessageBox.Show("Nu ati selectat data eliberarii!");
                return;
            }
            if (!IsNumber(txtCNP.Text))
            {
                MessageBox.Show("Campul CNP trebuie sa contina doar cifre!");
                return;
            }

            adv.Adresa = doctor.OfficeAddress;
            adv.Recomandare = recomandare;
            adv.DataEliberarii = Convert.ToDateTime(dataEliberare);
            adv.Observatii = boala;
            adv.DoctorID = doctor.DoctorID;
            adv.PatientID = patient.PatientID;
            adv.MotivulEliberarii = motiv;
            Debug.WriteLine($"ID PACIENT SELECTAT : {patient.PatientID} // ID DOCTOR {doctor.DoctorID}");
            if (await _medicalCertificateServices.AddMedicalCertificate(adv))
            {
                MessageBox.Show("Adeverinta medicala a fost salvata cu succes!");
                lm.Username = _doctorServices.GetAllDoctors().Where(x => x.DoctorID == Form1.User.UserID).First().Username;
                lm.OperationDescription = $"Adeverinta medicala creata pentru {patient.LastName} {patient.FirstName}.";
                lm.OperationDate = DateTime.Now;
                await _logger.Log(lm);
                this.Hide();
                Meniu m = new Meniu();
                m.Show();

            }
            else
            {
                MessageBox.Show("A aparut o eroare in momentul salvarii adeverintei medicale!");
            }


        }

        public void IncarcareDate()
        {
            MedicalCertificateModel adv = new MedicalCertificateModel();
            adv = _medicalCertificateServices.GetAllMedicalCertificates().Where(x => x.ID == Meniu.DocumentVizualizare.ID).First();
            txtBoala.Text = adv.Observatii;
            txtRecomandare.Text = adv.Recomandare;
            txtMotivEliberare.Text = adv.MotivulEliberarii;
            dtpDataEliberarii.Value = adv.DataEliberarii;
            txtNrFisa.Text = adv.ID.ToString();
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
