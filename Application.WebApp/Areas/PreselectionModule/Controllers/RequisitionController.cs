using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Entity.Entities.PreselectionModule;
using Application.Service.Services.Interfaces.PreselectionModule;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.WebApp.Areas.PreselectionModule.Controllers
{
    [Route("api/requisition")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {
        private IWebHostEnvironment environment;
        private readonly IRequisitionService requisitionService;
        public RequisitionController(IRequisitionService requisitionService, IWebHostEnvironment environment)
        {
            this.requisitionService = requisitionService;
            this.environment = environment;
        }

        [HttpPost]
        [Route("generaterequisition")]
        public async Task<IActionResult> GenerateRequisition(IFormCollection data)
        {
            try
            {
                string fileName = "";
                var file = Request.Form.Files[0];
                string HostUrl = this.environment.ContentRootPath;
                string filepath = "UploadedFiles/ManagementApprovalDocument";
                string uploadpath = Path.Combine(HostUrl,filepath);
                if (!Directory.Exists(uploadpath))
                {
                    Directory.CreateDirectory(uploadpath);
                }
                if (file.Length > 0)
                {
                    var timestamp = DateTime.Now.ToFileTime();
                    string timestampfilename = Convert.ToString(timestamp);
                    fileName = timestampfilename +"_"+ ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');                    
                    string fullPath = Path.Combine(uploadpath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                RequisitionFormData formData = new RequisitionFormData();
                formData.LocationId =Convert.ToInt32(data["LocationId"]);
                formData.VerticalId = Convert.ToInt32(data["VerticalId"]);
                formData.IOMNo = data["IOMNo"];
                formData.ManagementApprovalDocument = "/"+ filepath+"/" + fileName;
                string RequistionValue = data["RequisitionData"];
                formData.RequisitionData = JsonConvert.DeserializeObject<List<RequisitionDataObject>>(RequistionValue);
                formData.CreatedBy= Convert.ToInt32(data["CreatedBy"]);
                var response = await this.requisitionService.RequisitionInsert(formData).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("getallrequisition")]
        public async Task<IActionResult> GetAllRequisitionList(SearchRequisition search)
        {
            try
            {
                var response = await this.requisitionService.GetAllRequisitionList(search).ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("allocaterequisitiontorm")]
        public async Task<IActionResult> RequisitionAllocateToRM(RequisitionAllocationFormData formData)
        {
            try
            {
                var response = await this.requisitionService.RequisitionAllocateToRM(formData).ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("allocaterequisitiontosourcechannel")]
        public async Task<IActionResult> RequisitionAllocateSourceChannel(RequisitionSourceFormData formData)
        {
            try
            {
                var response = await this.requisitionService.RequisitionAllocateSourceChannel(formData).ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}