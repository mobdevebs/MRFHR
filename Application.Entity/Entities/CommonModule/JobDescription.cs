using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class JobDescription
    {
        public int JobDescriptionId { get; set; }
        public int VerticalId { get; set; }
        public string VerticalName { get; set; }
        public string JobDescriptionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }

    }

    public class SearchJobDescription
    {
        public int? JobDescriptionId { get; set; }
        public int? VerticalId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class JobDescriptionDetailFormData
    {
        public int JobDescriptionId { get; set; }
        public string JobDescriptionName { get; set; }
        public int VerticalId { get; set; }
        public int LocationId { get; set; }
        public int FunctionId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int GradeId { get; set; }
        public string ReportsTo { get; set; }
        public int NoOfReportees { get; set; }
        public string IndustryId { get; set; }
        public int ExperienceId { get; set; }
        public int QualificationId { get; set; }
        public int AgeId { get; set; }
        public int CourseId { get; set; }
        public int StreamId { get; set; }
        public int LanguageId { get; set; }
        public string AnyOtherLanguage { get; set; }
        public string JobPurpose { get; set; }
        public string JobSummary { get; set; }
        public string KPIs { get; set; }
        public string Dimensions { get; set; }
        public string Knowledge { get; set; }
        public string Skills { get; set; }
        public string ExternalStakeHolders { get; set; }
        public string InternalStakeHolders { get; set; }
        public string RestrictedJD { get; set; }
        public string JDDocument { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }

}
