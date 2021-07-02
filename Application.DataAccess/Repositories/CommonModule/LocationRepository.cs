using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.CommonModule
{
    public class LocationRepository : DatabaseContext, ILocationRepository
    {
        public LocationRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Location>> GetAllLocation(SearchLocation search)
        {
            try
            {
                List<Location> returnList = new List<Location>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@LocationId", search.LocationId);
                    para.Add("@VerticalId", search.VerticalId);
                    para.Add("@LocationNo", search.LocationNo);
                    para.Add("@LocationNo", search.LocationNo);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Location_GetAll";
                    connection.Open();
                    returnList = connection.Query<Location>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
