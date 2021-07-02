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
    public class CourseRepository : DatabaseContext, ICourseRepository
    {
        public CourseRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Course>> GetAllCourse(SearchCourse search)
        {
            try
            {
                List<Course> returnList = new List<Course>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Course_GetAll";
                    connection.Open();
                    returnList = connection.Query<Course>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<QualificationCourse>> GetAllQualificationCourse(SearchQualificationCourse search)
        {
            try
            {
                List<QualificationCourse> returnList = new List<QualificationCourse>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@QualificationId", search.QualificationId);
                    para.Add("@CourseId", search.CourseId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_QualificationCourse_GetAll";
                    connection.Open();
                    returnList = connection.Query<QualificationCourse>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
