namespace CustomAuthNetCore20.Authentication
{
    public struct Constants
    {
        public static readonly string UserInfoHeader = "x-userinfo";

        public struct Authorization
        {
            public static readonly string NameClaimType = "userinfo-name";
            public static readonly string EmailClaimType = "userinfo-email";
            public static readonly string UserIdClaimType = "userinfo-id";
            public static readonly string OidClaimType = "userinfo-oid";
        }
    }
}
