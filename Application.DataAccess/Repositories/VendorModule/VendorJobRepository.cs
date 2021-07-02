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
    public class VendorJobRepository : DatabaseContext, IVendorJobRepository
    {
        public VendorJobRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<CurrentJob>> GetCurrentJob(SearchCurrentJob search)
        {
            try
            {
                List<CurrentJob> returnList = new List<CurrentJob>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@PositionId", (search.PositionId.ToString() == "" ? 0 : search.PositionId));
                    para.Add("@FunctionId", (search.FunctionId.ToString() == "" ? 0 : search.FunctionId));
                    para.Add("@LocationId", (search.LocationId.ToString() == "" ? 0 : search.LocationId));
                    const string procName = "Usp_Vendor_CurrentJob";
                    connection.Open();
                    returnList = connection.Query<CurrentJob>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
