using ApplicantTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace ApplicantTracking.Infrastructure.Database.Mapping
{
    public class TimelineMap : IEntityTypeConfiguration<TimelinesEntity>
    {
        public void Configure(EntityTypeBuilder<TimelinesEntity> builder)
        {
            builder.ToTable("Timelines");

            builder.HasKey(x => x.IdTimeline);

            builder.Property(x => x.IdTimeline).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.IdTimelineType).IsRequired();

            builder.Property(x => x.IdAggregateRoot).IsRequired();

            builder.Property(x => x.OldData).IsRequired(false).HasDefaultValue(null);

            builder.Property(x => x.NewData).IsRequired(false).HasDefaultValue(null);

            builder.Property(x => x.CreatedAt).IsRequired();
    }
    }
}
