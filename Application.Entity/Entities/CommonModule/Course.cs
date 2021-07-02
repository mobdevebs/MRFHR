using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Course
    {

    }
    public class SearchCourse
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class QualificationCourse
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchQualificationCourse
    {
        public int? QualificationId { get; set; }
        public int? CourseId { get; set; }
        public bool? IsActive { get; set; }
    }
}
