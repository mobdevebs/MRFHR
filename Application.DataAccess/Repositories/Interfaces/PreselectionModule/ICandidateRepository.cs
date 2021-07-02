using Application.Entity.Entities.PreselectionModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.PreselectionModule
{
    public interface ICandidateRepository
    {
        Task<List<CandidateDetail>> GetCandidate(SearchCandidate search);
        Task<List<Candidate>> SaveCandidate(Candidate formdata);
    }
}
