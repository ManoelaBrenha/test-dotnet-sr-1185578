using ApplicantTracking.Infrastructure.Repositories.Interfaces;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Infrastructure.Database.Context;
using Microsoft.Extensions.Configuration;

namespace ApplicantTracking.Infrastructure.Repositories
{
    public class TimelinesRepository : BaseRepository<TimelinesEntity>, ITimelinesRepository
    {
        public TimelinesRepository(ApplicantTrackingDbContext applicantTrackingDbContext, IConfiguration configuration) : base(applicantTrackingDbContext, configuration)
        {

        }
    }
}
