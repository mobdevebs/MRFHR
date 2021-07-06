using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.CommonModule
{
    public interface ICommonRepository
    {
        Task<List<Age>> GetAllAge();
        Task<List<Years>> GetAllYears();
        Task<List<Months>> GetAllMonths();
        Task<List<Experience>> GetAllExperience();
         Task<List<State>> GetAllState();
    }
}
