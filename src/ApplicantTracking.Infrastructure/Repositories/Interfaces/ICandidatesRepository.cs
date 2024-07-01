using System;
using System.Collections.Generic;
using System.Linq;
using ApplicantTracking.Domain.Entities;

namespace ApplicantTracking.Infrastructure.Repositories.Interfaces
{
    public interface ICandidatesRepository : IBaseRepository<CandidatesEntity>
    {
    }
}
