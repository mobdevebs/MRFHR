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
    public class PositionRepository : DatabaseContext, IPositionRepository
    {
        public PositionRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<PositionVerticalDetail>> GetAllPositionVertical(SearchPosition search)
        {
            try
            {
                List<PositionVerticalDetail> returnList = new List<PositionVerticalDetail>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@VerticalId", search.VerticalId);
                    para.Add("@PositionId", search.PositionId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Position_GetAll";
                    connection.Open();
                    returnList = connection.Query<PositionVerticalDetail>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
