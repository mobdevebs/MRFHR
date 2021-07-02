using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.VendorModule
{
    public class VendorJob
    {
    }

    public class CurrentJob
    {
        public int JobDescriptonMasterId { get; set; }
        public string StateName { get; set; }
        public string CreatedOn { get; set; }
        public int IsSubmitted { get; set; }
        public int IsNew { get; set; }
        public string JobPurpose { get; set; }
        public string JobSummary { get; set; }
        public string JobType { get; set; }
        public string Range { get; set; }
    }

    public class SearchCurrentJob
    {
        public int? PositionId { get; set; }
        public int? FunctionId { get; set; }
        public int? LocationId { get; set; }
    }

    public class VendorActivityList
    {
        public int JobDescriptonMasterId { get; set; }
        public string Message { get; set; }
        public string Designation { get; set; }
        public int IsSubmitted { get; set; }
        public int IsNew { get; set; }
        public string JobPurpose { get; set; }
        public string JobSummary { get; set; }
    }
    public class SearchActivityList
    {
        public int? PositionId { get; set; }
        public int? FunctionId { get; set; }
        public int? LocationId { get; set; }
    }
}
