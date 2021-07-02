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
    [Route("api/domain")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IDomainService domainService;
        public DomainController(IDomainService domainService)
        {
            this.domainService = domainService;
        }

        [HttpPost]
        [Route("getalldomain")]
        public async Task<IActionResult> GetAllDomain(SearchDomain search)
        {
            try
            {
                var response = await this.domainService.GetAllDomain(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}