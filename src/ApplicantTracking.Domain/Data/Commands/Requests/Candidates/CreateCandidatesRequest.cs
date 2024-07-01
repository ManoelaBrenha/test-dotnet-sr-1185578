using System;

namespace ApplicantTracking.Domain.Data.Commands.Requests.Candidates
{
    public class CreateCandidatesRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }
}
