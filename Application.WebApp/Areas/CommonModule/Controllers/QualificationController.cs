﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.WebApp.Areas.CommonModule.Controllers
{
    [Route("api/qualification")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService qualificationService;
        public QualificationController(IQualificationService qualificationService)
        {
            this.qualificationService = qualificationService;
        }

        [HttpPost]
        [Route("getallqualification")]
        public async Task<IActionResult> GetAllQualification(SearchQualification search)
        {
            try
            {
                var response = await this.qualificationService.GetAllQualification(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
