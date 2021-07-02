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
    public class GradeRepository : DatabaseContext, IGradeRepository
    {
        public GradeRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }


        public async Task<List<PositionGrade>> GetAllPositionGrade(SearchPositionGrade search)
        {
            try
            {
                List<PositionGrade> returnList = new List<PositionGrade>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@GradeId", search.GradeId);
                    para.Add("@PositionId", search.PositionId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_GradePosition_GetAll";
                    connection.Open();
                    returnList = connection.Query<PositionGrade>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
