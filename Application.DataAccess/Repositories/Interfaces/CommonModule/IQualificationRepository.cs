using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.CommonModule
{
   public interface IQualificationRepository
    {
        Task<List<Qualification>> GetAllQualifaction(SearchQualification search);
        Task<List<QualificationType>> GetAllQualificationType(SearchQualification search);
    }
}
