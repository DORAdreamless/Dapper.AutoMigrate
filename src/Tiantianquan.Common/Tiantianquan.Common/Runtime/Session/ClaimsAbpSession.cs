using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Tiantianquan.Common.Runtime.Session
{
    /// <summary>
    /// Implements <see cref="IAbpSession"/> to get session properties from claims of <see cref="Thread.CurrentPrincipal"/>.
    /// </summary>
    public class ClaimsAbpSession : IAbpSession
    {
        public string UserId
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                {
                    return null;
                }

                var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                {
                    return null;
                }

                var userNameClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userNameClaim == null || string.IsNullOrEmpty(userNameClaim.Value))
                {
                    return null;
                }

                return userNameClaim.Value;
            }
        }
        public string UserName
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                {
                    return null;
                }

                var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                {
                    return null;
                }

                var userNameClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                if (userNameClaim == null || string.IsNullOrEmpty(userNameClaim.Value))
                {
                    return null;
                }

                return userNameClaim.Value;
            }
        }
        
    }
}