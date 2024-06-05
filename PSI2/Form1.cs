using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows.Forms;
using BCrypt.Net;
using System.Diagnostics;
using PSI2.Models;
using PSI2.Services;

namespace PSI2
{

    public partial class Form1 : Form
    {
        string username;
        string password;
        IEnumerable<DoctorModel> doctorList;
        DoctorServices _doctorServices = new DoctorServices();
        private AppDbContext _context;

        public static class User
        {
            public static int UserID { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            InitializeDbContext();
        }

        private void InitializeDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["PSI"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            _context = new AppDbContext(optionsBuilder.Options);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                username = txtUsername.Text;
                password = txtPassword.Text;
                string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
                var user = _context.Doctor.SingleOrDefault(u => u.Username == username);
                if (user == null)
                {
                    MessageBox.Show("Numele de utilizator sau parola sunt gresite!");
                    return;
                }
                doctorList = _doctorServices.GetAllDoctors();
                if (BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
                {
                    Debug.WriteLine($"e bun");
                    this.Hide();
                    Meniu m = new Meniu();
                    m.Show();
                    User.UserID = user.DoctorID;
                }
                else
                {
                    MessageBox.Show("Numele de utilizator sau parola sunt gresite!");
                }
                foreach (var item in doctorList)
                {
                    Debug.WriteLine($"{item.FirstName}");
                }
                Debug.WriteLine($"{BCrypt.Net.BCrypt.EnhancedHashPassword(password)} {user.Password}");
            }
            else
            {
                MessageBox.Show("Completeaza numele si parola!");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
