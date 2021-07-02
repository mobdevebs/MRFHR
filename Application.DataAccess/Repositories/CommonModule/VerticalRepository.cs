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
   public class VerticalRepository : DatabaseContext, IVerticalRepository
    {
        public VerticalRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Vertical>> GetAllVertical(SearchVertical search)
        {
            try
            {
                List<Vertical> returnList = new List<Vertical>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                     const string procName = "Usp_Vertical_GetAll";
                    connection.Open();
                    returnList = connection.Query<Vertical>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
