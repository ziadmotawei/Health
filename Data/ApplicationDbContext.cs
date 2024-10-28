using Health.Model;
using Microsoft.EntityFrameworkCore;

namespace Health.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(s => s.Appointments)
                .HasForeignKey(l => l.DoctorId);

            //modelBuilder.Entity<Appointment>()
            //.HasOne(a => a.Patient)
            //.WithMany(s => s.Appointments)
            //.HasForeignKey(l => l.Patient);

            modelBuilder.Entity<DoctorTreatments>()
                .HasKey(l => new { l.DoctorId, l.TreatmentId });

            modelBuilder.Entity<DoctorTreatments>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.DoctorTreatments)
                .HasForeignKey(l => l.DoctorId);

            modelBuilder.Entity<DoctorTreatments>()
                .HasOne(dt => dt.Treatment)
                .WithMany(t => t.DoctorTreatments)
                .HasForeignKey(dt => dt.TreatmentId);

            modelBuilder.Entity<PatientTreatments>()
                .HasKey(l => new { l.PatientId, l.TreatmentId });

            modelBuilder.Entity<PatientTreatments>()
                .HasOne(s => s.Patient)
                .WithMany(d => d.PatientTreatments)
                .HasForeignKey(l => l.PatientId);

            modelBuilder.Entity<PatientTreatments>()
                .HasOne(dt => dt.Treatment)
                .WithMany(t => t.PatientTreatments)
                .HasForeignKey(dt => dt.TreatmentId);


        }
    }
}
