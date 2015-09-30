using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace splc.domain
{

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(string username) : base(username)
        {

        }

        public SecurityLevel SecurityLevel { get; set; }


    }

    [Flags]
    public enum SecurityLevel
    {
        Open = 1,
        EyesOnly = 2
    }
}