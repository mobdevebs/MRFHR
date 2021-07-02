using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.DataAccess.Utility;
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
    public class UserRepository : DatabaseContext, IUserRepository
    {
        public UserRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<User>> GetAllUser(SearchAllUser search)
        {
            try
            {
                List<User> returnList = new List<User>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@UserId", search.UserId);
                    para.Add("@RoleId", search.RoleId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Users_GetAll";
                    connection.Open();
                    returnList = connection.Query<User>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginUserStatus> GetLoginUser(LoginFormData formdata)
        {
            try
            {
                LoginUserStatus status = new LoginUserStatus();
                User returnList = new User();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@UserId", formdata.UserId);
                    const string procName = "Usp_Users_GetAll";
                    connection.Open();
                    returnList = connection.Query<User>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (returnList != null)
                    {
                        status.Status = 1;
                        if (returnList.IsActive == true)
                        {
                            string dbpass = returnList.Password;
                            string dbsaltkey = returnList.SaltKey;
                            if (CommonUtility.EncodePassword(formdata.Password, dbsaltkey) != dbpass)
                            {
                                status.Status = 0;
                                returnList = null;
                            }
                        }
                        else
                        {
                            status.Status = 0;
                            returnList = null;
                        }
                    }
                    status.LoginUser = returnList;

                    return await Task.FromResult(status);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
