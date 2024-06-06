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
    public class RetetaMedicalaServices
    {
        public RetetaMedicalaServices()
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

        public async Task<bool> AddRetetaMedicala(RetetaMedicalaModel reteta)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.RetetaMedicala.AddAsync(reteta);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la adaugare unei retetei medicale! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        public List<RetetaMedicalaModel> GetAllReteteMedicala()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.RetetaMedicala.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, we just throw it again
                throw new Exception("An error occurred while fetching Retete Medicale", ex);
            }
        }
    }
}
