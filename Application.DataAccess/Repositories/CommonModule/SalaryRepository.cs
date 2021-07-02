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
    public class SalaryRepository : DatabaseContext, ISalaryRepository
    {
        public SalaryRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Salary>> GetAllSalary(SearchSalary search)
        {
            try
            {
                List<Salary> returnList = new List<Salary>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@SalaryId", search.SalaryId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Salary_GetAll";
                    connection.Open();
                    returnList = connection.Query<Salary>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
