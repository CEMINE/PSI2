﻿using Microsoft.EntityFrameworkCore;
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
                    await context.Logbook.AddAsync(log);
                    await context.SaveChangesAsync();
                    Debug.WriteLine("Log-ul a fost adaugat cu succes!");
                    return true;
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Eroare la adaugarea unui log in db. {ex}");
                return false;
            }
        }

        public List<LogModel> GetAllLogs()
        {
            try
            {
                using (var context = new AppDbContext(_contextOptions))
                {
                    return context.Logbook.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exista o eroare la preluarea log-urilor! \n Eroarea: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return null;
            }
        }
    }
}
