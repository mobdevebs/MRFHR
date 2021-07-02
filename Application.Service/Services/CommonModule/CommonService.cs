﻿using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
    public class CommonService:ICommonService
    {
        private readonly ICommonRepository commonRepository;

        public CommonService(ICommonRepository commonRepository)
        {
            this.commonRepository = commonRepository;
        }

        public async Task<List<Age>> GetAllAge()
        {
            return await this.commonRepository.GetAllAge();
        }

        public async Task<List<Experience>> GetAllExperience()
        {
            return await this.commonRepository.GetAllExperience();
        }
    }
}
