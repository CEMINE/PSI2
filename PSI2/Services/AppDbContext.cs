﻿using Microsoft.EntityFrameworkCore;
using System.Numerics;
using PSI2.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<DoctorModel> Doctor { get; set; }
    public DbSet<PatientModel> Patient { get; set; }
    public DbSet<LogModel> Logbook { get; set; }
    public DbSet<MedicalCertificateModel> MedicalCertificate { get; set; }
    public DbSet<BiletTrimitereModel> BiletTrimitere { get; set; }
    public DbSet<ConcediuMedicalModel> ConcediuMedical { get; set; }
    public DbSet<FisaConsultatiiModel> FisaConsultatii { get; set; }
    public DbSet<RetetaMedicalaModel> RetetaMedicala { get; set; }
}