using System;
using ApplicantTracking.Domain.Data.Commands.Requests.Candidates;
using ApplicantTracking.Domain.Data.Commands.Responses.Candidates;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Infrastructure.Database.Handler.Interfaces;
using ApplicantTracking.Infrastructure.Repositories.Interfaces;

namespace ApplicantTracking.Infrastructure.Database.Handler
{
    public class CreateCandidatesHandler : ICreateCandidatesHandler
    {
        ICandidatesRepository _candidatesRepository;
        ITimelinesRepository _timelinesRepository;

        public CreateCandidatesHandler(ICandidatesRepository candidatesRepository) {
            _candidatesRepository = candidatesRepository;
        }

        public CreateCandidatesResponse Handle(CreateCandidatesRequest command)
        {
            DateTime data = DateTime.Now;
            CandidatesEntity entity = new CandidatesEntity {
                Name = command.Name,
                CreatedAt = data,
                Birthdate = command.Birthdate,
                Email = command.Email,
                Surname = command.Surname
            };

            _candidatesRepository.Add(entity);

            return null;
        }
    }
}
