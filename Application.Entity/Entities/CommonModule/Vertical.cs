using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Vertical
    {
        public int VerticalId { get; set; }
        public string VerticalName { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchVertical
    {
        public int? VerticalId { get; set; }
        public string VerticalName { get; set; }
        public bool? IsActive { get; set; }
    }
}
