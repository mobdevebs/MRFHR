using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Services.Interfaces.CommonModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApp.Areas.CommonModule.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IStatusService statusService;
        private readonly ICommonService commonService;
        public CommonController(
            IStatusService statusService,
            ICommonService commonService
            )
        {
            this.statusService = statusService;
            this.commonService = commonService;
        }

        [HttpGet]
        [Route("getallstatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            try
            {
                var response = await this.statusService.GetAllStatus().ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getallage")]
        public async Task<IActionResult> GetAllAge()
        {
            try
            {
                var response = await this.commonService.GetAllAge().ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getallexperience")]
        public async Task<IActionResult> GetAllExperience()
        {
            try
            {
                var response = await this.commonService.GetAllExperience().ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}