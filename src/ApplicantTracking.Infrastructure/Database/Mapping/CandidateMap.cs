using ApplicantTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicantTracking.Infrastructure.Database.Mapping
{
    public class CandidateMap : IEntityTypeConfiguration<CandidatesEntity>
    {
        public void Configure(EntityTypeBuilder<CandidatesEntity> builder)
        {
            builder.ToTable("Candidates");

            builder.HasKey(x => x.IdCandidate);

            builder.Property(x => x.IdCandidate).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Surname).IsRequired();

            builder.Property(x => x.Birthdate).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.LastUpdateAt).IsRequired(false).HasDefaultValue(null);
    }
    }
}
