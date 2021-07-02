using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApp.Areas.CommonModule.Controllers
{
    [Route("api/jobdescription")]
    [ApiController]
    public class JobDescriptionController : ControllerBase
    {
        private readonly IJobDescriptionService jobdescriptionService;
        public JobDescriptionController(IJobDescriptionService jobdescriptionService)
        {
            this.jobdescriptionService = jobdescriptionService;
        }

        [HttpPost]
        [Route("getalljobdescription")]
        public async Task<IActionResult> GetAllJobDescription(SearchJobDescription search)
        {
            try
            {
                var response = await this.jobdescriptionService.GetAllJobDescription(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("savejobdescription")]
        public async Task<IActionResult> SaveJobDescription(JobDescriptionDetailFormData param)
        {
            try
            {
                var response = await this.jobdescriptionService.SaveJobDescription(param).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}