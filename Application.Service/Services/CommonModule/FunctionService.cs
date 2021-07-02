using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            this.functionRepository = functionRepository;
        }
        public async Task<List<VerticalFunction>> GetAllVerticalFunction(SearchFunction search)
        {
            return await this.functionRepository.GetAllVerticalFunction(search);
        }
    }
}
