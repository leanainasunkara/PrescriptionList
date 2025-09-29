using Microsoft.EntityFrameworkCore;
using System;

namespace PrescriptionList.Models
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options)
            : base(options)
        { }

        public DbSet<Prescription> Prescriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    MedicationName = "Atorvastatin",
                    FillStatus = "New",
                    Cost = 19.99,
                    RequestDate = new DateTime(2025, 10, 1, 14, 0, 0)
                }
            );
        }
    }
}