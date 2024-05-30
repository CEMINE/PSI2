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
    public partial class Meniu : Form
    {
        IEnumerable<PatientModel> patientList;
        PatientServices _patientServices = new PatientServices();

        public Meniu()
        {
            InitializeComponent();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            patientList = _patientServices.GetAllPatients();
            List<string> listaNumePacienti = new List<string>();
            foreach(var item in patientList)
            {
                listaNumePacienti.Add(item.LastName + " " + item.FirstName);
            }
            listBox1.DataSource = listaNumePacienti;
        }

        private void btnAdaugaPacient_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdaugaPacient ap = new AdaugaPacient();
            ap.Show();
        }
    }
}
