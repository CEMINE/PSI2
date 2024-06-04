using Microsoft.EntityFrameworkCore;
using PSI2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI2.Services
{
    public class MedicalCertificateServices
    {
        public MedicalCertificateServices()
        {
            InitializeDbContext();
        }

        private DbContextOptions<AppDbContext> _contextOptions;

        private void InitializeDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["PSI"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            _contextOptions = optionsBuilder.Options;
        }

        public async Task<bool> AddMedicalCertificate(MedicalCertificateModel mcm)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.MedicalCertificate.AddAsync(mcm);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la adaugare unei adeverinte medicale! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        public async Task<MedicalCertificateModel> GetMedicalCertificate(int patientId)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return await context.MedicalCertificate.Where(x => x.PatientID == patientId).FirstAsync();
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la preluarea unei adeverinte medicale! \n Eroarea: " + ex.Message);
                return null;
            }
        }

        public List<MedicalCertificateModel> GetAllMedicalCertificates()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.MedicalCertificate.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, we just throw it again
                throw new Exception("An error occurred while fetching Medical Certificates", ex);
            }
        }
    }
}
