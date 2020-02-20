using System;

namespace CustomAuthNetCore20.Authentication
{
    public class UserInfo
    {
        public Guid Oid { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}
