using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.Interfaces.CommonModule
{
    public interface IPositionService
    {
        Task<List<PositionVerticalDetail>> GetAllPositionVertical(SearchPosition search);
        Task<List<PositionGrade>> GetAllPositionGrade(SearchPositionGrade search);
    }
}
