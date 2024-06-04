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
using PSI2.Models;
using PSI2.Services;

namespace PSI2
{
    public partial class Meniu : Form
    {
        IEnumerable<PatientModel> patientList;
        PatientServices _patientServices = new PatientServices();
        int selectedPatientId = 0;

        public static class Patient
        {
            public static int PatientID { get; set; }
        }

        public Meniu()
        {
            InitializeComponent();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            patientList = _patientServices.GetAllPatients();
            PopulateListBox();
        }

        private void btnAdaugaPacient_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdaugaPacient ap = new AdaugaPacient();
            ap.Show();
        }

        public class ListBoxItem
        {
            public int Id { get; set; }
            public string FullName { get; set; }

            public ListBoxItem(int id, string firstName, string lastName)
            {
                Id = id;
                FullName = $"{firstName} {lastName}";
            }

            public override string ToString()
            {
                return FullName;
            }
        }

        private void PopulateListBox()
        {
            List<ListBoxItem> patients = new List<ListBoxItem>();
            foreach (var item in patientList)
            {
                patients.Add(new ListBoxItem(item.PatientID, item.LastName, item.FirstName));
            }

            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = patients;
        }

        private void SearchByFullName(List<PatientModel> filteredList)
        {
            List<ListBoxItem> patients = new List<ListBoxItem>();
            foreach (var item in filteredList)
            {
                patients.Add(new ListBoxItem(item.PatientID, item.LastName, item.FirstName));
            }

            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = patients;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedItem = (ListBoxItem)listBox1.SelectedItem;
                selectedPatientId = selectedItem.Id;
                string selectedName = selectedItem.FullName;

                //MessageBox.Show($"Selected ID: {selectedId}, Name: {selectedName}");
                Patient.PatientID = selectedPatientId;
                Debug.WriteLine($"id pacient selectat: {Patient.PatientID}");
            }
        }

        private void txtCautare_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtCautare.Text.ToLower();
            var filteredList = patientList
                .Where(p => $"{p.FirstName} {p.LastName}".ToLower().Contains(searchText))
                .ToList();
            SearchByFullName(filteredList);

        }

        private void btnAdaugaAdeverinta_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdeverintaMedicala adeverintaMedicala = new AdeverintaMedicala();
            adeverintaMedicala.Show();
        }

        private void btnAdaugaBilet_Click(object sender, EventArgs e)
        {
            this.Hide();
            BiletTrimitere btm = new BiletTrimitere();
            btm.Show();
        }
    }
}
