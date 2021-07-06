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
    public class QualificationRepository : DatabaseContext, IQualificationRepository
    {
        public QualificationRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Qualification>> GetAllQualifaction(SearchQualification search)
        {
            try
            {
                List<Qualification> returnList = new List<Qualification>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@QualificationId", search.QualificationId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Qualification_GetAll";
                    connection.Open();
                    returnList = connection.Query<Qualification>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<QualificationType>> GetAllQualificationType(SearchQualification search)
        {
            try
            {
                List<QualificationType> returnList = new List<QualificationType>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@QualificationId", search.QualificationId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_QualificationType_GetAll";
                    connection.Open();
                    returnList = connection.Query<QualificationType>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
