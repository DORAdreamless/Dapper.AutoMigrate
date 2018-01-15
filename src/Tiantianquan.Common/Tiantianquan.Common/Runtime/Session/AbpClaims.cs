//using Microsoft.Owin.Security.OAuth;

namespace Tiantianquan.Common.Runtime.Session
{
    /// <summary>
    /// Used to get Abp-specific claim type names.
    /// </summary>
    public static class AbpClaimTypes
    {
       // public static OAuthBearerAuthenticationOptions OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        /// <summary>
        /// IdentityProvider
        /// </summary>
        public const string IdentityProvider = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";


        public const string FullName = "http://www.weixiaobang.cn/identity/claims/FullName";
        public const string NickName = "http://www.weixiaobang.cn/identity/claims/NickName";
        public const string Phone = "http://www.weixiaobang.cn/identity/claims/Phone";
        public const string Email = "http://www.weixiaobang.cn/identity/claims/Email";
        public const string HeadImageUrl = "http://www.weixiaobang.cn/identity/claims/HeadImageUrl";
        public const string UserName = "http://www.weixiaobang.cn/identity/claims/UserName";
    }
}