﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchQualification
    {
        public int? QualificationId { get; set; }
        public bool? IsActive { get; set; }
    }
}
