using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.VendorModule
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string AlternateEmailId { get; set; }
        public string ContactNo { get; set; }
        public string AlternateContactNo { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string TermsOfService { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchVendor
    {
        public int VendorId { get; set; }
        public bool IsActive { get; set; }
    }
}
