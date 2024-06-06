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
    public class FisaConsultatiiServices
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public FisaConsultatiiServices()
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

        public async Task<bool> AddFisaConsultatii(FisaConsultatiiModel fc)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.FisaConsultatii.AddAsync(fc);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la adaugare unei fise de consultatii! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        public List<FisaConsultatiiModel> GetAllFiseConsultatii()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.FisaConsultatii.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la preluarea fiselor de consultatii! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return null;
            }
        }
    }
}
