using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.PreselectionModule;
using Application.Entity.Entities.PreselectionModule;
using Application.Service.Services.Interfaces.PreselectionModule;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.PreselectionModule
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public async Task<List<CandidateDetail>> GetCandidate(SearchCandidate search)
        {
            return await this.candidateRepository.GetCandidate(search);
        }

        public async Task<List<Candidate>> SaveCandidate(Candidate formdata)
        {
            return await this.candidateRepository.SaveCandidate(formdata);
        }
    }
}
