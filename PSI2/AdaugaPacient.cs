﻿using PSI2.Models;
using PSI2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI2
{
    public partial class AdaugaPacient : Form
    {
        public AdaugaPacient()
        {
            InitializeComponent();
        }
        char? sex;
        PatientServices _patientServices = new PatientServices();
        string nume, prenume, telefon, adresa, cnp, serie, numar, cetatenie, stareCivila;
        DateTime dataNasterii;

        public static bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to validate the email string
            return regex.IsMatch(email);
        }

        public async void AddToDb()
        {
            PatientModel patientModel = new PatientModel();

            nume = txtNume.Text;
            prenume = txtPrenume.Text;
            telefon = txtTelefon.Text;
            adresa = txtAdresa.Text;
            cnp = txtCNP.Text;
            serie = txtSerie.Text;
            numar = txtNumar.Text;
            cetatenie = txtCetatenie.Text;
            stareCivila = txtStareCivila.Text;
            dataNasterii = dtpDataNasterii.Value;
            Debug.WriteLine($"{nume} {prenume}");

            if (String.IsNullOrEmpty(nume))
            {
                MessageBox.Show($"Nu ati completat numele de familie al pacientului!");
                return;
            }
            if (String.IsNullOrEmpty(prenume))
            {
                MessageBox.Show("Nu ati completat prenumele de familie al pacientului!");
                return;
            }
            if (dataNasterii == null)
            {
                MessageBox.Show("Nu ati completat data nasterii a pacientului!");
                return;
            }
            if (sex == null)
            {
                MessageBox.Show("Nu ati selectat sex-ul!");
                return;
            }
            if (String.IsNullOrEmpty(telefon))
            {
                MessageBox.Show("Nu ati completat numarul de telefon!");
                return;
            }
            if (telefon.Length < 10)
            {
                MessageBox.Show("Numarul de telefon trebuie sa fie format din 10 cifre!");
                return;
            }
            if (String.IsNullOrEmpty(adresa))
            {
                MessageBox.Show("Nu ati completat adresa!");
                return;
            }
            if (cnp.Length < 13)
            {
                MessageBox.Show("CNP-ul trebuie sa contina 13 cifre!");
                return;
            }
            if (serie.Length < 2)
            {
                MessageBox.Show("Seria trebuie sa contina 2 caractere!");
                return;
            }
            if (numar.Length < 6)
            {
                MessageBox.Show("Numarul trebuie sa contina 6 caractere");
                return;
            }
            if (String.IsNullOrEmpty(cetatenie))
            {
                MessageBox.Show("Nu ati completat cetatenia!");
                return;
            }
            if (String.IsNullOrEmpty(stareCivila))
            {
                MessageBox.Show("Nu ati completat starea civila!");
                return;
            }

            patientModel.FirstName = txtPrenume.Text;
            patientModel.LastName = txtNume.Text;
            patientModel.DateOfBirth = dtpDataNasterii.Value;
            patientModel.Gender = Convert.ToChar(sex);
            patientModel.PhoneNumber = txtTelefon.Text;
            patientModel.Email = txtEmail.Text;
            patientModel.Address = txtAdresa.Text;
            patientModel.CNP = txtCNP.Text;
            patientModel.Serie = txtSerie.Text;
            patientModel.Numar = txtNumar.Text;
            patientModel.Cetatenie = txtCetatenie.Text;
            patientModel.StareCivila = txtStareCivila.Text;
            if(await _patientServices.AddPatient(patientModel))
            {
                MessageBox.Show("Pacient adaugat cu success!");
                this.Hide();
                Meniu m = new Meniu();
                m.Show();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Meniu meniu = new Meniu();
            meniu.Show();
        }

        private void rbtM_CheckedChanged(object sender, EventArgs e)
        {
            sex = 'M';
        }

        private void rbtF_CheckedChanged(object sender, EventArgs e)
        {
            sex = 'F';
        }

        private void btnAdaugaPacient_Click(object sender, EventArgs e)
        {
            AddToDb();
        }
    }
}
