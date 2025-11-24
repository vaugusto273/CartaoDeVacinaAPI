using CartaoDeVacinaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartaoDeVacinaAPI.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VaccinationRecord>()
                .HasOne(vr => vr.User)
                .WithMany(u => u.VaccinationRecords)
                .HasForeignKey(vr => vr.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VaccinationRecord>()
                .HasOne(vr => vr.Vaccine)
                .WithMany(u => u.VaccinationRecords)
                .HasForeignKey(vr => vr.VaccineID);

            modelBuilder.Entity<VaccinationRecord>()
                .HasIndex(vr => new { vr.UserID, vr.VaccineID, vr.DoseNumber })
                .IsUnique();
        }
    }
}
