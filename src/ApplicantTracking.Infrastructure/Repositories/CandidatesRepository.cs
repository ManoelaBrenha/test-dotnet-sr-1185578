using ApplicantTracking.Infrastructure.Repositories.Interfaces;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Infrastructure.Database.Context;
using Microsoft.Extensions.Configuration;

namespace ApplicantTracking.Infrastructure.Repositories
{
    public class CandidatesRepository : BaseRepository<CandidatesEntity>, ICandidatesRepository
    {
        public CandidatesRepository(ApplicantTrackingDbContext applicantTrackingDbContext, IConfiguration configuration) : base(applicantTrackingDbContext, configuration)
        {
        }
    }
}
