using Application.DataAccess.Repositories.Interfaces.PreselectionModule;
using Application.Entity.Entities.CommonModule;
using Application.Entity.Entities.PreselectionModule;
using Application.Service.Services.Interfaces.PreselectionModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.PreselectionModule
{
    public class RequisitionService : IRequisitionService
    {
        private readonly IRequisitionRepository requisitionRepository;

        public RequisitionService(IRequisitionRepository requisitionRepository)
        {
            this.requisitionRepository = requisitionRepository;
        }
        public async Task<ReturnMessage> RequisitionInsert(RequisitionFormData formData)
        {
            return await this.requisitionRepository.RequisitionInsert(formData);
        }

        public async Task<List<RequisitionList>> GetAllRequisitionList(SearchRequisition formData)
        {
            return await this.requisitionRepository.GetAllRequisitionList(formData);
        }

        public async Task<ReturnMessage> RequisitionAllocateToRM(RequisitionAllocationFormData formData)
        {
            return await this.requisitionRepository.RequisitionAllocateToRM(formData);
        }

        public async Task<ReturnMessage> RequisitionAllocateSourceChannel(RequisitionSourceFormData formData)
        {
            return await this.requisitionRepository.RequisitionAllocateSourceChannel(formData);
        }
    }
}
