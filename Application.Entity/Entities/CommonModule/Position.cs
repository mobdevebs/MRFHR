using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }

    public class PositionVertical
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string VerticalIds { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }

    public class SearchPosition
    {
        public int? VerticalId { get; set; }
        public int? PositionId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class PositionVerticalDetail
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string VerticalIds { get; set; }
        public string VerticalNames { get; set; }
        public bool IsActive { get; set; }
    }

    public class PositionGrade
    {
        public int PositionId { get; set; }
        public int VerticalId { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
    }

    public class SearchPositionGrade
    {
        public int? PositionId { get; set; }
        public int? GradeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
