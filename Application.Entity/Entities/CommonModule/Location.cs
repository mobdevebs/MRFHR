using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Location
    {
        public int LocationId { get; set; }
        public int VerticalId { get; set; }
        public string LocationNo { get; set; }
        public string LocationCode { get; set; }
        public string LocationOffice { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }

    public class SearchLocation
    {
        public int? LocationId { get; set; }
        public int? VerticalId { get; set; }
        public string LocationNo { get; set; }
        public string LocationCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
