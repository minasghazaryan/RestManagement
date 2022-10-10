using Microsoft.AspNetCore.Identity;
using System;

namespace RestManagement.DataAccess.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
