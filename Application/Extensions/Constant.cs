
namespace Application.Extensions
{
    public static class Constant
    {
        public const string RegisterRoute = "api/Account/identity/create";
        public const string LoginRoute = "api/Account/identity/login";
        public const string RefreshTokenRoute = "api/Account/identity/refresh-token";
        public const string GetRolesRoute = "api/Account/identity/role/list";
        public const string CreateRoleRoute = "api/Acount/identity/role/create";
        public const string CreateAdminRoute = "setting";
        public const string BrowserStorageKey = "x-key";
        public const string HttpClientName = "WebUIClient";
        public const string HttpClientHeaderScheme = "Bearer";
        public const string GetuserWithRolesRoute = "api/Account/identity/user-with-roiles";
        public const string ChangeUserRoleRoute = "api/Account/identity/change-role";
        public const string AuthenticationType = "JwtAuthen";
        public static class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
    }
}
