using Application.Entity.Entities.CommonModule;
using Application.Entity.Entities.PreselectionModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.Interfaces.PreselectionModule
{
    public interface IRequisitionRepository
    {
        Task<ReturnMessage> RequisitionInsert(RequisitionFormData formData);
        Task<List<RequisitionList>> GetAllRequisitionList(SearchRequisition formData);
        Task<ReturnMessage> RequisitionAllocateToRM(RequisitionAllocationFormData formData);
        Task<ReturnMessage> RequisitionAllocateSourceChannel(RequisitionSourceFormData formData);
    }
}
