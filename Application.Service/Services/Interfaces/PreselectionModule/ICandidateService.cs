using Application.Entity.Entities.PreselectionModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.Interfaces.PreselectionModule
{
   public interface ICandidateService
    {
        Task<List<CandidateDetail>> GetCandidate(SearchCandidate search);
        Task<List<Candidate>> SaveCandidate(Candidate formdata);
    }
}
