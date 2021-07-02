using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class ReturnMessage
    {
        public string Msg { get; set; }
        public string ErrorMsg { get; set; }
        public int SuccessFlag { get; set; }
        public long Id { get; set; }
        public string RefNo { get; set; }
    }
}
