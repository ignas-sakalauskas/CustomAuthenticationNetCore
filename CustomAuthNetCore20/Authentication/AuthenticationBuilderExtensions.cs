using System;
using Microsoft.AspNetCore.Authentication;

namespace CustomAuthNetCore20.Authentication
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddUserInfoAuth(this AuthenticationBuilder builder, Action<UserInfoAuthOptions> configureOptions)
        {
            return builder.AddScheme<UserInfoAuthOptions, UserInfoAuthHandler>(UserInfoAuthOptions.DefaultScheme, configureOptions);
        }
    }
}
