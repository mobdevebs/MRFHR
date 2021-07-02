using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.CommonModule
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser(SearchAllUser search);
        Task<LoginUserStatus> GetLoginUser(LoginFormData formdata);
    }
}
