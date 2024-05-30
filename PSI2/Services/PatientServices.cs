using Microsoft.EntityFrameworkCore;
using PSI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSI2.Models;
using System.Configuration;

namespace PSI2.Services
{
    public class PatientServices
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public PatientServices()
        {
            InitializeDbContext();
        }

        private void InitializeDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["PSI"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            _contextOptions = optionsBuilder.Options;
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.Patient.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching doctors.", ex);
            }
        }

        public async Task<bool> AddPatient(PatientModel patient)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.Patient.AddAsync(patient);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }
    }
}
