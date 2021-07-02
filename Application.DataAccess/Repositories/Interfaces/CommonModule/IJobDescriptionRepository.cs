using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.CommonModule
{
    public interface IJobDescriptionRepository
    {
        Task<List<JobDescription>> GetAllJobDescription(SearchJobDescription search);
        Task<ReturnMessage> SaveJobDescription(JobDescriptionDetailFormData param);
    }
}
