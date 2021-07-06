﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;


namespace Application.WebApp.Areas.CommonModule.Controllers
{
    [Route("api/stream")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly IStreamService streamService;
        public StreamController(IStreamService streamService)
        {
            this.streamService = streamService;
        }

        [HttpPost]
        [Route("getallstream")]
        public async Task<IActionResult> GetAllStream(SearchStream search)
        {
            try
            {
                var response = await this.streamService.GetAllStream(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("getallqualificationcoursestream")]
        public async Task<IActionResult> GetAllQualificationCourseStream(SearchQualificationCourseStream search)
        {
            try
            {
                var response = await this.streamService.GetAllQualificationCourseStream(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
