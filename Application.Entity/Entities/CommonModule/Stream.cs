﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
  public  class Stream
    {
    }
    public class SearchStream
    {
        public int? StreamId { get; set; }
        public string StreamName { get; set; }
        
    }

    public class QualificationCourseStream
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int StreamId { get; set; }
        public string StreamName { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchQualificationCourseStream
    {
        public int? QualificationId { get; set; }
        public int? CourseId { get; set; }
        public int? StreamId { get; set; }
        public bool? IsActive { get; set; }
    }
}
