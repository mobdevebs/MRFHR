using Application.Entity.Entities.VendorModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.VendorModule
{
    public interface IVendorRepository
    {
        Task<List<Vendor>> GetAllVendor(SearchVendor search);
    }
}
