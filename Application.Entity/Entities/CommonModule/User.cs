using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity.Entities.CommonModule
{
    public class User
    {
        public int AutoUserId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public string RoleIds { get; set; }
        public string RoleNames { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
    }

    public class SearchAllUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class LoginFormData
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserStatus
    {
        public int Status { get; set; }
        public User LoginUser { get; set; }
    }
}
