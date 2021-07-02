using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUser(SearchAllUser search)
        {
            return await this.userRepository.GetAllUser(search);
        }

        public async Task<LoginUserStatus> GetLoginUser(LoginFormData formData)
        {
            return await this.userRepository.GetLoginUser(formData);
        }
    }
}
