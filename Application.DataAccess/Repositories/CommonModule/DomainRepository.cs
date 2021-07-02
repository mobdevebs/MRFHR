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
    public class  DomainRepository : DatabaseContext, IDomainRepository
    {
        public DomainRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Domain>> GetAllDomain(SearchDomain search)
        {
            try
            {
                List<Domain> returnList = new List<Domain>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@DomainId", search.DomainId);
                    para.Add("@ParentDomainId", search.ParentDomainId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Domain_GetAll";
                    connection.Open();
                    returnList = connection.Query<Domain>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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
