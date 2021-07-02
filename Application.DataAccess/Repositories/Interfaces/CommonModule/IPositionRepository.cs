using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.CommonModule
{
    public interface IPositionRepository
    {
        Task<List<PositionVerticalDetail>> GetAllPositionVertical(SearchPosition search);
        Task<List<PositionGrade>> GetAllPositionGrade(SearchPositionGrade search);
    }
}
