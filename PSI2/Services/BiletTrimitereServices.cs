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
    public class BiletTrimitereServices
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public BiletTrimitereServices()
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

        public async Task<bool> AddBiletTrimitere(BiletTrimitereModel bt)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.BiletTrimitere.AddAsync(bt);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la adaugare unui bilet de trimitere! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        public IEnumerable<BiletTrimitereModel> GetAllBileteTrimitere()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.BiletTrimitere.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la preluarea biletelor de trimitere! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return null;
            }
        }
    }
}
