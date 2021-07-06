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
    public class CommonRepository : DatabaseContext, ICommonRepository
    {
        public CommonRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<Age>> GetAllAge()
        {
            try
            {
                List<Age> returnList = new List<Age>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Age_GetAll";
                    connection.Open();
                    returnList = connection.Query<Age>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<State>> GetAllState()
        {
            try
            {
                List<State> returnList = new List<State>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_State_GetAll";
                    connection.Open();
                    returnList = connection.Query<State>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Years>> GetAllYears()
        {
            try
            {
                List<Years> returnList = new List<Years>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Years_GetAll";
                    connection.Open();
                    returnList = connection.Query<Years>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Months>> GetAllMonths()
        {
            try
            {
                List<Months> returnList = new List<Months>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Months_GetAll";
                    connection.Open();
                    returnList = connection.Query<Months>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Experience>> GetAllExperience()
        {
            try
            {
                List<Experience> returnList = new List<Experience>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    const string procName = "Usp_Experience_GetAll";
                    connection.Open();
                    returnList = connection.Query<Experience>(procName, para, commandType: CommandType.StoredProcedure).ToList();
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


