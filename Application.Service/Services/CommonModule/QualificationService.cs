﻿using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
  public  class QualificationService : IQualificationService
    {
        private IQualificationRepository qualificationRepository;
        public QualificationService(IQualificationRepository iQualificationRepository)
        {
            this.qualificationRepository = iQualificationRepository;
        }
        public async Task<List<Qualification>> GetAllQualification(SearchQualification search)
        {
            return await this.qualificationRepository.GetAllQualifaction(search);
        }
        public async Task<List<QualificationType>> GetAllQualificationType(SearchQualification search)
        {
            return await this.qualificationRepository.GetAllQualificationType(search);
        }
    }
}
