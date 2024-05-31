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
    public class Logger
    {
        private DbContextOptions<AppDbContext> _contextOptions;

        public Logger()
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

        public async Task<bool> Log(LogModel log)
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    await context.Log.AddAsync(log);
                    await context.SaveChangesAsync();
                    return true;
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Eroare la adaugarea unui log in db. {ex}");
                return false;
            }
        }
    }
}
