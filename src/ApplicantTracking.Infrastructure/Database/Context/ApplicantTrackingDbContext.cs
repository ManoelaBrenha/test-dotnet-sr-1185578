using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Infrastructure.Database.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ApplicantTracking.Infrastructure.Database.Context
{
    public class ApplicantTrackingDbContext : DbContext
    {
        public ApplicantTrackingDbContext(DbContextOptions <ApplicantTrackingDbContext> options):base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CandidatesEntity>(new CandidateMap().Configure);
            modelBuilder.Entity<TimelinesEntity>(new TimelineMap().Configure);
        }

        public DbSet<CandidatesEntity> Candidates { get; set; }
        public DbSet<TimelinesEntity> Timelines { get; set; }
    }
}
