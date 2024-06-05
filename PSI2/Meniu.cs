using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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
        IEnumerable<IDocument> docsList;
        PatientServices _patientServices = new PatientServices();
        BiletTrimitereServices _btServices = new BiletTrimitereServices();
        MedicalCertificateServices _medicalCertificateServices = new MedicalCertificateServices();
        int selectedPatientId = 0;
        int selectedDocumentId = 0;

        public static class Patient
        {
            public static int PatientID { get; set; }
        }

        public static class DocumentVizualizare
        {
            public static int ID { get; set; }
            public static string DocType { get; set; }
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

        public class DocumentListBoxItem
        {
            public int Id { get; set; }
            public string DocumentType { get; set; }

            public DocumentListBoxItem(int id, string doctype)
            {
                Id = id;
                DocumentType = doctype;
            }

            public override string ToString()
            {
                return DocumentType;
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

        private void PopulateDocumentListBox()
        {
            List<DocumentListBoxItem> lst = new List<DocumentListBoxItem>();
            foreach (var item in docsList)
            {
                lst.Add(new DocumentListBoxItem(item.DocID, item.DocType));
            }

            listBox2.DisplayMember = "DocumentType";
            listBox2.ValueMember = "Id";
            listBox2.DataSource = lst;
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
            //listele sunt functionale
            //trebuie adaugate si concatenate listele in docsList in momentul in care vor fi adaugate si alte documente
            docsList = null;
            var a = _btServices.GetAllBileteTrimitere().Where(x => x.PatientID == selectedPatientId).ToList();
            var b = _medicalCertificateServices.GetAllMedicalCertificates().Where(x => x.PatientID == selectedPatientId).ToList();
            docsList = (a ?? Enumerable.Empty<IDocument>()).Concat(b ?? Enumerable.Empty<IDocument>());


            PopulateDocumentListBox();
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedItem = (DocumentListBoxItem)listBox2.SelectedItem;
                selectedDocumentId = selectedItem.Id;
                string selectedName = selectedItem.DocumentType;

                //MessageBox.Show($"Selected ID: {selectedId}, Name: {selectedName}");
                DocumentVizualizare.ID = selectedDocumentId;
                DocumentVizualizare.DocType = selectedName;
                Debug.WriteLine($"id document selectat: {DocumentVizualizare.ID} // tip document selectat {DocumentVizualizare.DocType}");
            }
        }

        private void btnVizualizareDocument_Click(object sender, EventArgs e)
        {
            //trebuie adaugate if-uri sau facut un switch pentru fiecare tip de document
            if(DocumentVizualizare.DocType.Contains("BiletTrimitere"))
            {
                BiletTrimitere btm = new BiletTrimitere();
                btm.Show();
                btm.IncarcareDate();
            }
            if(DocumentVizualizare.DocType.Contains("MedicalCertificate"))
            {
                AdeverintaMedicala a = new AdeverintaMedicala();
                a.Show();
                a.IncarcareDate();
            }
        }
    }
}
