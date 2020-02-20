using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace CustomAuthNetCore20.Authentication
{
    public class UserInfoAuthHandler : AuthenticationHandler<UserInfoAuthOptions>
    {
        public UserInfoAuthHandler(IOptionsMonitor<UserInfoAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder,
                ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            await Task.Delay(100).ConfigureAwait(false);

            var isAuthenticated = Request.Headers.TryGetValue("x-userinfo", out StringValues userinfoValues);

            if (!isAuthenticated)
            {
                return AuthenticateResult.Fail("The request is not correctly authenticated.");
            }

            var userInfo = GetUserInfo(userinfoValues);
            var userPrincipal = CreateClaimsPrincipal(userInfo);

            var ticket = new AuthenticationTicket(userPrincipal, Options.Scheme);

            return AuthenticateResult.Success(ticket);
        }

        private UserInfo GetUserInfo(StringValues values)
        {
            var bytes = Convert.FromBase64String(values);
            var json = Encoding.UTF8.GetString(bytes);

            var header = JsonConvert.DeserializeObject<UserInfoHeader>(json);

            return new UserInfo
            {
                FullName = header.UserFullName,
                EmailAddress = header.UserEmail
            };
        }

        private ClaimsPrincipal CreateClaimsPrincipal(UserInfo userInfo)
        {
            var claims = new List<Claim> {
                new Claim(Constants.Authorization.NameClaimType, userInfo.FullName, ClaimValueTypes.String, Options.ClaimsIssuer),
                new Claim(Constants.Authorization.EmailClaimType, userInfo.EmailAddress, ClaimValueTypes.String, Options.ClaimsIssuer),
                new Claim(Constants.Authorization.UserIdClaimType, "10", ClaimValueTypes.Integer32, Options.ClaimsIssuer),
                new Claim(Constants.Authorization.OidClaimType, "{49900eb9-f762-4897-864c-7b1b464fe244}", ClaimValueTypes.String, Options.ClaimsIssuer)
            };

            var userIdentity = new ClaimsIdentity(claims, Options.Scheme);

            return new ClaimsPrincipal(userIdentity);
        }
    }
}
