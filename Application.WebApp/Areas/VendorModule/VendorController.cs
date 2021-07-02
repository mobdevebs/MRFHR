using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entity.Entities.VendorModule;
using Application.Service.Services.Interfaces.VendorModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApp.Areas.VendorModule
{
    [Route("api/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService vendorService;
        public VendorController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }

        [HttpPost]
        [Route("getallvendor")]
        public async Task<IActionResult> GetAllVendor(SearchVendor search)
        {
            try
            {
                var response = await this.vendorService.GetAllVendor(search).ConfigureAwait(false);

                return this.Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}