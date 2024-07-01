using ApplicantTracking.Domain.Data.Commands.Requests.Candidates;
using ApplicantTracking.Domain.Data.Commands.Responses.Candidates;

namespace ApplicantTracking.Infrastructure.Database.Handler.Interfaces
{
    public interface ICreateCandidatesHandler
    {
        CreateCandidatesResponse Handle(CreateCandidatesRequest command);
    }
}
