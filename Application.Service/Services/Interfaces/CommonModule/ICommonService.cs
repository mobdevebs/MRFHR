using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.Interfaces.CommonModule
{
    public interface ICommonService
    {
        Task<List<Age>> GetAllAge();
        Task<List<Months>> GetAllMonths();
        Task<List<Years>> GetAllYears();
        Task<List<State>> GetAllState();
        Task<List<Experience>> GetAllExperience();
    }
}
