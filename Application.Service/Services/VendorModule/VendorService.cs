using Application.DataAccess.Repositories.Interfaces.VendorModule;
using Application.Entity.Entities.VendorModule;
using Application.Service.Services.Interfaces.VendorModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Application.Service.Services.VendorModule
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        public async Task<List<Vendor>> GetAllVendor(SearchVendor search)
        {
            return await this.vendorRepository.GetAllVendor(search);
        }
    }
}
