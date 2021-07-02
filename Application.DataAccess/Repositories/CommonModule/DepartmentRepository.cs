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
    public class DepartmentRepository : DatabaseContext, IDepartmentRepository
    {
        public DepartmentRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<FunctionDepartment>> GetAllFunctionDepartment(SearchDepartment search)
        {
            try
            {
                List<FunctionDepartment> returnList = new List<FunctionDepartment>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@DepartmentId", search.DepartmentId);
                    para.Add("@FunctionId", search.FunctionId);
                    para.Add("@VerticalId", search.VerticalId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Department_GetAll";
                    connection.Open();
                    returnList = connection.Query<FunctionDepartment>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
