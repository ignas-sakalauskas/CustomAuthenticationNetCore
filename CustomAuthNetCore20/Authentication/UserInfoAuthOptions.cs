using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace CustomAuthNetCore20.Authentication
{
    public class UserInfoAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "userinfo";
        public string Scheme => DefaultScheme;
        public StringValues AuthKey { get; set; }
    }
}
