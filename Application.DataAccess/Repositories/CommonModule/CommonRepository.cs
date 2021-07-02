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
    public class CommonRepository : DatabaseContext, ICommonRepository
    {
        public CommonRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Age>> GetAllAge()
        {
            try
            {
                List<Age> returnList = new List<Age>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Age_GetAll";
                    connection.Open();
                    returnList = connection.Query<Age>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Experience>> GetAllExperience()
        {
            try
            {
                List<Experience> returnList = new List<Experience>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Experience_GetAll";
                    connection.Open();
                    returnList = connection.Query<Experience>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
