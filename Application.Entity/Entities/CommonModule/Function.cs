using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Function
    {
        public int FunctionId { get; set; }
        public int VerticalId { get; set; }
        public string FunctionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }

    public class SearchFunction
    {
        public int? FunctionId { get; set; }
        public int? VerticalId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class VerticalFunction
    {
        public int FunctionId { get; set; }
        public int VerticalId { get; set; }
        public string VerticalName { get; set; }
        public string FunctionName { get; set; }
        public bool IsActive { get; set; }
    }
}
