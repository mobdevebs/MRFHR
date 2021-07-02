using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
        }

        public async Task<List<PositionVerticalDetail>> GetAllPositionVertical(SearchPosition search)
        {
            return await this.positionRepository.GetAllPositionVertical(search);
        }

        public async Task<List<PositionGrade>> GetAllPositionGrade(SearchPositionGrade search)
        {
            return await this.positionRepository.GetAllPositionGrade(search);
        }
    }
}
