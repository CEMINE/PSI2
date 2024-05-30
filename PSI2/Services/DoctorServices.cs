using Microsoft.EntityFrameworkCore;
using PSI2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI2.Services
{
    public class DoctorServices
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public DoctorServices()
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

        public IEnumerable<DoctorModel> GetAllDoctors()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.Doctor.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, we just throw it again
                throw new Exception("An error occurred while fetching doctors.", ex);
            }
        }
    }

}
