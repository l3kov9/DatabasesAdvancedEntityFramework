using Microsoft.EntityFrameworkCore;

namespace Hospital.Models.Context
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=HospitalDb;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PatientMedicament>()
                .HasKey(pm => new
                {
                    pm.PatientId,
                    pm.MedicamentId
                });

            builder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient)
                .HasForeignKey(v => v.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Medicaments)
                .WithOne(m => m.Patient)
                .HasForeignKey(m => m.PatientId);

            builder.Entity<Medicament>()
                .HasMany(m => m.Patients)
                .WithOne(p => p.Medicament)
                .HasForeignKey(p => p.MedicamentId);

            builder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId);
        }
    }
}
