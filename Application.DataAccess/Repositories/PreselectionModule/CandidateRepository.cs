using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.PreselectionModule;
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
    public class CandidateRepository : DatabaseContext, ICandidateRepository
    {
        public CandidateRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }
        public async Task<List<CandidateDetail>> GetCandidate(SearchCandidate search)
        {
            try
            {
                List<CandidateDetail> returnList = new List<CandidateDetail>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@CandidateId", search.CandidateId);
                    para.Add("@IsActive", search.IsActive);
                    para.Add("@Search", search.Search);
                    const string procName = "Usp_Candidate_GetAll";
                    connection.Open();
                    returnList = connection.Query<CandidateDetail>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ReturnMessage> SaveCandidateStatus(CandidateStatus formdata)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@CandidateId", formdata.CandidateId);
                    para.Add("@RequisitionId", formdata.RequisitionId);
                    para.Add("@Remarks", formdata.Remarks);
                    para.Add("@CreatedBy", formdata.CreatedBy);
                    para.Add("@StatusId", formdata.StatusId);
                    const string procName = "Usp_CandidateStatus_InsertUpdate";
                    connection.Open();
                    rm = connection.Query<ReturnMessage>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
                    return await Task.FromResult(rm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReturnMessage> SaveCandidateCMDStatus(CandidateCmdStatus formdata)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@CandidateId", formdata.CandidateId);
                    para.Add("@CMDApprovalDocument", formdata.CMDApprovalDocument);
                    para.Add("@CMDApprovalNo", formdata.CMDApprovalNo);
                    para.Add("@CreatedBy", formdata.CreatedBy);
                    para.Add("@CMDApprovalRequired", formdata.CMDApprovalRequired);
                    para.Add("@CMDApprovalStatus", formdata.CMDApprovalStatus);
                    const string procName = "Usp_CandidateCMDStatus_InsertUpdate";
                    connection.Open();
                    rm = connection.Query<ReturnMessage>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
                    return await Task.FromResult(rm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ReturnMessage> SaveCandidate(Candidate formdata)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@CandidateId", formdata.CandidateId);
                    para.Add("@PrefixId", formdata.PrefixId);
                    para.Add("@FullName", formdata.FullName);
                    para.Add("@GenderId", formdata.GenderId);
                    para.Add("@DOB", formdata.DOB);
                    para.Add("@Age", formdata.Age);
                    para.Add("@EmailId", formdata.EmailId);
                    para.Add("@ContactNo", formdata.ContactNo);
                    para.Add("@AadharNo", formdata.AadharNo);
                    para.Add("@MotherTongueId", formdata.MotherTongueId);
                    para.Add("@LaguageIds", formdata.LanguageIds);
                    para.Add("@QualificationId", formdata.QualificationId);
                    para.Add("@CourseId", formdata.CourseId);
                    para.Add("@StreamId", formdata.StreamId);
                    para.Add("@MarksPercentage", formdata.MarksPercentage);
                    para.Add("@CompletionYear", formdata.CompletionYear);
                    para.Add("@QualificationTypeId", formdata.QualificationTypeId);
                    para.Add("@ExperienceYear", formdata.ExperienceYear);
                    para.Add("@ExperienceMonth", formdata.ExperienceMonth);
                    para.Add("@CurrentCTC", formdata.CurrentCTC);
                    para.Add("@CurrentEmployer", formdata.CurrentEmployer);
                    para.Add("@CurrentDesignation", formdata.CurrentDesignation);
                    para.Add("@DomainId", formdata.DomainId);
                    para.Add("@SubDomainId", formdata.SubDomainId);
                    para.Add("@StateId", formdata.StateId);
                    para.Add("@PreviousApplied", formdata.PreviousApplied);
                    para.Add("@RelativeStatus", formdata.RelativeStatus);
                    para.Add("@RelativeName", formdata.RelativeName);
                    para.Add("@RelativeContactNo", formdata.RelativeContactNo);
                    para.Add("@ParentRelationshipId", formdata.ParentRelationshipId);
                    para.Add("@ChildRelationshipId", formdata.ChildRelationshipId);
                    para.Add("@RelationshipNotes", formdata.RelationshipNotes);
                    para.Add("@CMDApprovalRequired", formdata.CMDApprovalRequired);
                    para.Add("@CMDApprovalStatus", formdata.CMDApprovalStatus);
                    para.Add("@CMDApprovalNo", formdata.CMDApprovalNo);
                    para.Add("@CMDApprovalDocument", formdata.CMDApprovalDocument);
                    para.Add("@Resume", formdata.Resume);
                    para.Add("@IsEmployee", formdata.IsEmployee);
                    para.Add("@CreatedBy", formdata.CreatedBy);
                    para.Add("@Status", formdata.Status);
                    para.Add("@SourceChannelId", formdata.SourceChannelId);
                    const string procName = "Usp_Candidate_InsertUpdate";
                    connection.Open();
                    rm = connection.Query<ReturnMessage>(procName, para, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
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
