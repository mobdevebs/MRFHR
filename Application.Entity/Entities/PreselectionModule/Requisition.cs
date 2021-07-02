using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.PreselectionModule
{
    public class RequisitionFormData
    {
        public long RequisitionId { get; set; }
        public int LocationId { get; set; }
        public int VerticalId { get; set; }
        public string IOMNo { get; set; }
        public string ManagementApprovalDocument { get; set; }
        public int CreatedBy { get; set; }
        public List<RequisitionDataObject> RequisitionData { get; set; }

    }

    public class RequisitionDataObject
    {
        public int AutoId { get; set; }
        public string IOMNo { get; set; }
        public int FunctionId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int GradeId { get; set; }
        public int JobTypeId { get; set; }
        public int JobDescriptionId { get; set; }
        public string TargetDate { get; set; }
        public int ApproveCount { get; set; }
        public int RequestCount { get; set; }
        public int HoldCount { get; set; }
        public bool IsAutoApproved { get; set; }
    }

    public class RequisitionList
    {
        public long RequisitionApprovalId { get; set; }
        public long RequisitionDetailHistoryId { get; set; }
        public long RequisitionDetailId { get; set; }
        public long RequisitionId { get; set; }
        public string RequisitionNo { get; set; }
        public int LocationId { get; set; }
        public string LocationNo { get; set; }
        public int FunctionId { get; set; }
        public string FunctionName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public int JobDescriptionId { get; set; }
        public string JobDescriptionName { get; set; }
        public string TargetDate { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedByAutoUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string CreatedByEmailId { get; set; }
        public int ApproverAutoUserId { get; set; }
        public string ApproverUserName { get; set; }
        public string ApproverEmailId { get; set; }
        public int ApproveCount { get; set; }
        public int RequestCount { get; set; }
        public int HoldCount { get; set; }
        public int RequisitionApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovalStatusIcon { get; set; }
        public int RequisitionProcessStatusId { get; set; }
        public string ProcessStatus { get; set; }
        public string ProcessStatusIcon { get; set; }
    }

    public class SearchRequisition
    {
        public string RequisitionNo { get; set; }
        public long? RequistionId { get; set; }
        public long? RequisitionDetailHistoryId { get; set; }
        public int? LocationId { get; set; }
        public int? VerticalId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string IOMNo { get; set; }
        public int? RequisitionApprovalStatus { get; set; }
        public int? RequisitionProcessStatus { get; set; }
        public int? CreatedBy { get; set; }
        public int? ApproverAutoUserId { get; set; }
    }

    public class RequisitionAllocationFormData
    {
        public long RequisitionDetailHistoryId { get; set; }
        public int AllocatedAutoUserId { get; set; }
        public int SalaryId { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }

    public class RequisitionSourceFormData
    {
        public long RequisitionDetailHistoryId { get; set; }
        public string VendorIds { get; set; } 
        public List<RequisitionSourceChannelFeature> SourceChannelFeature { get; set; }
        public int CreatedBy { get; set; }
    }

    public class RequisitionSourceChannelFeature
    {
        public int SourceChannelId { get; set; }
        public int JobDescriptionFeatureId { get; set; }
        public string Notes { get; set; }
    }

}
