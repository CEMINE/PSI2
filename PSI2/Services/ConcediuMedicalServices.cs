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
    public class ConcediuMedicalServices
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public ConcediuMedicalServices()
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

        public async Task<bool> AddConcediuMedical(ConcediuMedicalModel cm)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.ConcediuMedical.AddAsync(cm);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la adaugarea concediului medical! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        public List<ConcediuMedicalModel> GetAllConcediiMedicale()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.ConcediuMedical.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la preluarea concediilor medicale! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return null;
            }
        }
    }
}
