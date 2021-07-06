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
    [Route("api/function")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService functionService;
        public FunctionController(IFunctionService functionService)
        {
            this.functionService = functionService;
        }

        [HttpPost]
        [Route("getallverticalfunction")]
        public async Task<IActionResult> GetAllVerticalFunction(SearchFunction search)
        {
            try
            {
                var response = await this.functionService.GetAllVerticalFunction(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}