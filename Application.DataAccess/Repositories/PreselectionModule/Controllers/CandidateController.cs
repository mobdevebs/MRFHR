using Application.Entity.Entities.PreselectionModule;
using Application.Service.Services.Interfaces.PreselectionModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApp.Areas.PreselectionModule.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        [HttpPost]
        [Route("getcandidateprofile")]
        public async Task<IActionResult> GetCandidateProfile(SearchCandidate search)
        {
            try
            {
                var response = await this.candidateService.GetCandidate(search).ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("savecandidateprofile")]
        public async Task<IActionResult> SaveCandidateProfile(Candidate search)
        {
            try
            {
                var response = await this.candidateService.SaveCandidate(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("savecandidatestatus")]
        public async Task<IActionResult> SaveCandidateStatus(CandidateStatus search)
        {
            try
            {
                var response = await this.candidateService.SaveCandidateStatus(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("savecandidatecmdstatus")]
        public async Task<IActionResult> SaveCandidateCMDStatus(CandidateCmdStatus search)
        {
            try
            {
                var response = await this.candidateService.SaveCandidateCMDStatus(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
