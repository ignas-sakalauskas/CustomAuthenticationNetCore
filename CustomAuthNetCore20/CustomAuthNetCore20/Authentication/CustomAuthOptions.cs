using Microsoft.AspNetCore.Authentication;

namespace CustomAuthNetCore20.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "custom auth";
        public string Scheme => DefaultScheme;
        public string AuthKey { get; set; }
    }
}