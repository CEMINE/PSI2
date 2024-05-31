﻿using Microsoft.EntityFrameworkCore;
using PSI2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                MessageBox.Show("Exista o eroare la adaugare unei adeverinte medicale! \n Eroarea: " + ex.Message);
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
                MessageBox.Show("Exista o eroare la preluarea unei adeverinte medicale! \n Eroarea: " + ex.Message);
                return null;
            }
        }
    }
}
