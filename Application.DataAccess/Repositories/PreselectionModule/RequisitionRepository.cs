using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.PreselectionModule;
using Application.DataAccess.Utility;
using Application.Entity.Entities.CommonModule;
using Application.Entity.Entities.PreselectionModule;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.PreselectionModule
{
    public class RequisitionRepository : DatabaseContext, IRequisitionRepository
    {
        public RequisitionRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<ReturnMessage> RequisitionInsert(RequisitionFormData formData)
        {
            try
            {
                DataTable dtObject = CommonUtility.ToDataTable<RequisitionDataObject>(formData.RequisitionData);
                ReturnMessage rm = new ReturnMessage();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@LocationId", formData.LocationId);
                    para.Add("@VerticalId", formData.VerticalId);
                    para.Add("@IOMNo", formData.IOMNo);
                    para.Add("@ManagementApprovalDocument", formData.ManagementApprovalDocument);
                    para.Add("@RequisitionData", dtObject, DbType.Object, ParameterDirection.Input, null);
                    para.Add("@CreatedBy", formData.CreatedBy);
                    const string procName = "Usp_Requisition_InsertUpdate";
                    connection.Open();
                    rm = connection.Query<ReturnMessage>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return await Task.FromResult(rm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RequisitionList>> GetAllRequisitionList(SearchRequisition formData)
        {
            try
            {
                List<RequisitionList> dataList = new List<RequisitionList>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@RequisitionNo", formData.RequisitionNo);
                    para.Add("@RequistionId", formData.RequistionId);
                    para.Add("@RequisitionDetailHistoryId", formData.RequisitionDetailHistoryId);
                    para.Add("@LocationId", formData.LocationId);
                    para.Add("@VerticalId", formData.VerticalId);
                    para.Add("@FromDate", formData.FromDate);
                    para.Add("@ToDate", formData.ToDate);
                    para.Add("@IOMNo", formData.IOMNo);
                    para.Add("@RequisitionApprovalStatus", formData.RequisitionApprovalStatus);
                    para.Add("@RequisitionProcessStatus", formData.RequisitionProcessStatus);
                    para.Add("@CreatedBy", formData.CreatedBy);
                    para.Add("@ApproverAutoUserId", formData.ApproverAutoUserId);
                    const string procName = "Usp_Requisition_GetAll";
                    connection.Open();
                    dataList = connection.Query<RequisitionList>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(dataList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReturnMessage> RequisitionAllocateToRM(RequisitionAllocationFormData formData)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@RequisitionDetailHistoryId", formData.RequisitionDetailHistoryId);
                    para.Add("@AllocatedAutoUserId", formData.AllocatedAutoUserId);
                    para.Add("@SalaryId", formData.SalaryId);
                    para.Add("@Remarks", formData.Remarks);
                    para.Add("@CreatedBy", formData.CreatedBy);
                    const string procName = "Usp_RequisitionAllocateToRM";
                    connection.Open();
                    rm = connection.Query<ReturnMessage>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return await Task.FromResult(rm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReturnMessage> RequisitionAllocateSourceChannel(RequisitionSourceFormData formData)
        {
            try
            {
                DataTable dtObject = CommonUtility.ToDataTable<RequisitionSourceChannelFeature>(formData.SourceChannelFeature);
                ReturnMessage rm = new ReturnMessage();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@RequisitionDetailHistoryId", formData.RequisitionDetailHistoryId);
                    para.Add("@VendorIds", formData.VendorIds);
                    para.Add("@SourceChannelFeature", dtObject, DbType.Object, ParameterDirection.Input, null);
                    para.Add("@CreatedBy", formData.CreatedBy);
                    const string procName = "Usp_RequisitionAllocateSourceChannel";
                    connection.Open();
                    rm = connection.Query<ReturnMessage>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return await Task.FromResult(rm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
