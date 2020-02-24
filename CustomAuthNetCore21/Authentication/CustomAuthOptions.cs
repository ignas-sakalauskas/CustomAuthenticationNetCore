using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace CustomAuthNetCore21.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "custom auth";
        public string Scheme => DefaultScheme;
        public StringValues AuthKey { get; set; }
    }
}