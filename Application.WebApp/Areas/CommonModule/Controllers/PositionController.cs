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
    [Route("api/position")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService positionService;
        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        [HttpPost]
        [Route("getallverticalposition")]
        public async Task<IActionResult> GetAllVerticalPosition(SearchPosition search)
        {
            try
            {
                var response = await this.positionService.GetAllPositionVertical(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("getallpositiongrade")]
        public async Task<IActionResult> GetAllPositionGrade(SearchPositionGrade search)
        {
            try
            {
                var response = await this.positionService.GetAllPositionGrade(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}