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
    public class FunctionRepository : DatabaseContext, IFunctionRepository
    {
        public FunctionRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<VerticalFunction>> GetAllVerticalFunction(SearchFunction search)
        {
            try
            {
                List<VerticalFunction> returnList = new List<VerticalFunction>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@FunctionId", search.FunctionId);
                    para.Add("@VerticalId", search.VerticalId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Function_GetAll";
                    connection.Open();
                    returnList = connection.Query<VerticalFunction>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
