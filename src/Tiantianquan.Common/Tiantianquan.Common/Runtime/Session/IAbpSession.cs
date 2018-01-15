using System;

namespace Tiantianquan.Common.Runtime.Session
{
    /// <summary>
    /// Defines some session information that can be useful for applications.
    /// </summary>
    public interface IAbpSession
    {
   

        /// <summary>
        /// 用户名称
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        string UserName { get; }
        
    }
}