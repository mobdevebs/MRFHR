using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
   public class VerticalService : IVerticalService
    {
        private readonly IVerticalRepository verticalRepository;

        public VerticalService(IVerticalRepository iverticalRepository)
        {
            this.verticalRepository = iverticalRepository;
        }

        public async Task<List<Vertical>> GetAllVertical (SearchVertical search)
        {
            return await this.verticalRepository.GetAllVertical(search);
        }
    }
}
