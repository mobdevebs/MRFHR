using Application.Entity.Entities.VendorModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.Interfaces.VendorModule
{
    public interface IVendorService
    {
        Task<List<Vendor>> GetAllVendor(SearchVendor search);
    }
}
