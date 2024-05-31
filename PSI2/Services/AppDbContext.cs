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
    public DbSet<LogModel> Log { get; set; }
}