using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Domain
    {
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public int ParentDomainId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
    public class SearchDomain
    {
        public int? DomainId { get; set; }
        public int? ParentDomainId { get; set; }
        public bool IsActive { get; set; }
    }
}
