using Application.Entity.Entities.CommonModule;
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
        Task<ReturnMessage> SaveCandidate(Candidate formdata);
        Task<ReturnMessage> SaveCandidateStatus(CandidateStatus formdata);
        Task<ReturnMessage> SaveCandidateCMDStatus(CandidateCmdStatus formdata);
    }
}
