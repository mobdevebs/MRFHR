using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.PreselectionModule
{
    public class Candidate
    {
        public string Status { get; set; }
        public int CandidateId { get; set; }
        public int PrefixId { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public int GenderId { get; set; }
        // public string GenderName { get; set; }
        public string DOB { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string AadharNo { get; set; }
        public int MotherTongueId { get; set; }
        //   public string MotherTongue { get; set; }
        public string LanguageIds { get; set; }
        // public string Languages { get; set; }
        public int QualificationId { get; set; }
        //  public string Qualification { get; set; }
        public int CourseId { get; set; }
        // public string Course { get; set; }
        public int StreamId { get; set; }
        // public string Stream { get; set; }
        public decimal MarksPercentage { get; set; }
        public int CompletionYear { get; set; }
        public int QualificationTypeId { get; set; }
        //   public string QualificationType { get; set; }
        public int ExperienceYear { get; set; }
        public int ExperienceMonth { get; set; }
        public decimal CurrentCTC { get; set; }
        public string CurrentEmployer { get; set; }
        public string CurrentDesignation { get; set; }
        public int DomainId { get; set; }
        //  public string Domain { get; set; }
        public int SubDomainId { get; set; }
        // public string SubDomain { get; set; }
        public int StateId { get; set; }
        // public string State { get; set; }
        public bool PreviousApplied { get; set; }
        public bool RelativeStatus { get; set; }
        public string RelativeName { get; set; }
        public string RelativeContactNo { get; set; }
        public int ParentRelationshipId { get; set; }
        public int ChildRelationshipId { get; set; }
        public string RelationshipNotes { get; set; }
        public int CMDApprovalRequired { get; set; }
        public bool CMDApprovalStatus { get; set; }
        public string CMDApprovalNo { get; set; }
        public string CMDApprovalDocument { get; set; }
        public string Resume { get; set; }
        public bool IsEmployee { get; set; }
        public int SourceChannelId { get; set; }
        public int CreatedBy { get; set; }
    }

    public class CandidateCmdStatus
    {
        public int CreatedBy { get; set; }
        public int CandidateId { get; set; }
        public int CMDApprovalRequired { get; set; }
        public bool CMDApprovalStatus { get; set; }
        public string CMDApprovalNo { get; set; }
        public string CMDApprovalDocument { get; set; }
    }
    public class SearchCandidate
    {
        public int? CandidateId { get; set; }
        public bool? IsActive { get; set; }
        public string Search { get; set; }
    }

    public class CandidateStatus
    {
        public int RequisitionId { get; set; }
        public int CandidateId { get; set; }
        public int StatusId { get; set; }
        public int CreatedBy { get; set; }
        public string Remarks { get; set; }
    }

    public class CandidateDetail
    {
        public int CandidateId { get; set; }
        public string Prefix { get; set; }
        public string FullName { get; set; }
        public string GenderName { get; set; }
        public string QualificationType { get; set; }
        public string DOB { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string AadharNo { get; set; }
        public string MotherTongue { get; set; }
        public string Languages { get; set; }
        public string Qualification { get; set; }
        public string Course { get; set; }
        public string Stream { get; set; }
        public string MarksPercentage { get; set; }
        public string CompletionYear { get; set; }
        public int ExperienceYear { get; set; }
        public int ExperienceMonth { get; set; }
        public string CurrentCTC { get; set; }
        public string CurrentEmployer { get; set; }
        public string CurrentDesignation { get; set; }
        public string Domain { get; set; }
        public string SubDomain { get; set; }
        public string State { get; set; }
        public string PreviousApplied { get; set; }
        public string RelativeStatus { get; set; }
        public string RelativeName { get; set; }
        public string RelativeContactNo { get; set; }
        public string Resume { get; set; }
        public string IsEmployee { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public string SourceChannelName { get; set; }
        public int Age { get; set; }
    }
}
