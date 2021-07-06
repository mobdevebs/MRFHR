using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.DataAccess.Utility;
using Application.Entity.Entities.CommonModule;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.CommonModule
{
    public class UserRepository : DatabaseContext, IUserRepository
    {
        public UserRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<User>> SaveUser(User search)
        {
            try
            {
                List<User> returnList = new List<User>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@EmailId", search.EmailId);
                    para.Add("@Password", search.Password);
                    para.Add("@Role", "External");
                    const string procName = "Usp_UserMaster_InsertUpdate";
                    connection.Open();
                    returnList = connection.Query<User>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    //#region Mail
                    //var mailMessage = new MailMessage();
                    //mailMessage.To.Add(new MailAddress(search.EmailId));
                    //mailMessage.From = new MailAddress("namrata.netbased@gmail.com");
                    //mailMessage.Subject = "MRF";
                    //mailMessage.IsBodyHtml = true;
                    //mailMessage.Body = "Hi.......";
                    //using (var smtp = new SmtpClient())
                    //{
                    //    var credential = new NetworkCredential
                    //    {
                    //        UserName = "",//gmail id n pwd
                    //        Password = ""
                    //    };
                    //    try
                    //    {
                    //        smtp.Host = "smtp.gmail.com";
                    //        smtp.Port = 587;
                    //        smtp.EnableSsl = true;
                    //        smtp.UseDefaultCredentials = false;
                    //        smtp.Credentials = credential;
                    //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //        smtp.Send(mailMessage);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        throw;
                    //    }
                    //}
                    //#endregion

                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
