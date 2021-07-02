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
    public class StreamRepository : DatabaseContext, IStreamRepository
    {
        public StreamRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Stream>> GetAllStream(SearchStream Stream)
        {
            try
            {
                List<Stream> returnList = new List<Stream>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Stream_GetAll";
                    connection.Open();
                    returnList = connection.Query<Stream>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<QualificationCourseStream>> GetAllQualificationCourseStream(SearchQualificationCourseStream search)
        {
            try
            {
                List<QualificationCourseStream> returnList = new List<QualificationCourseStream>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@QualificationId", search.QualificationId);
                    para.Add("@CourseId", search.CourseId);
                    para.Add("@StreamId", search.StreamId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_QualificationCourseStream_GetAll";
                    connection.Open();
                    returnList = connection.Query<QualificationCourseStream>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
