using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.VendorModule;
using Application.Entity.Entities.VendorModule;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.VendorModule
{
    public class VendorRepository : DatabaseContext, IVendorRepository
    {
        public VendorRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Vendor>> GetAllVendor(SearchVendor search)
        {
            try
            {
                List<Vendor> returnList = new List<Vendor>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@VendorId", search.VendorId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Vendor_GetAll";
                    connection.Open();
                    returnList = connection.Query<Vendor>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
