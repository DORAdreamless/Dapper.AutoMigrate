using System;

namespace Tiantianquan.Common.Runtime.Session
{
    /// <summary>
    /// Implements null object pattern for <see cref="IAbpSession"/>.
    /// </summary>
    public class NullAbpSession : IAbpSession
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullAbpSession Instance { get { return SingletonInstance; } }

        public Guid? AdminUserId => null;

        public string UserId => string.Empty;

        public Guid? CompanyId => null;

        public string CompanyName => string.Empty;

        public Guid? RoleId => null;

        public string RoleName => string.Empty;

        public string UserName => string.Empty;

        public int? CompanyType => null;

        public string CompanyAreaId => string.Empty;

        private static readonly NullAbpSession SingletonInstance = new NullAbpSession();

        private NullAbpSession()
        {
        }
    }
}