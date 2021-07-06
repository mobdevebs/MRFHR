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
    [Route("api/vertical")]
    [ApiController]
    public class VerticalController : ControllerBase
    {
        private readonly IVerticalService verticalService;
        public VerticalController(IVerticalService verticalService)
        {
            this.verticalService = verticalService;
        }

        [HttpPost]
        [Route("getallvertical")]
        public async Task<IActionResult> GetAllVertical(SearchVertical search)
        {
            try
            {
                var response = await this.verticalService.GetAllVertical(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}