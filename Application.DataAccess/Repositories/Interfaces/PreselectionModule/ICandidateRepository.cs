using Application.Entity.Entities.CommonModule;
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
        Task<ReturnMessage> SaveCandidate(Candidate formdata);
        Task<ReturnMessage> SaveCandidateStatus(CandidateStatus formdata);
        Task<ReturnMessage> SaveCandidateCMDStatus(CandidateCmdStatus formdata);
    }
}
