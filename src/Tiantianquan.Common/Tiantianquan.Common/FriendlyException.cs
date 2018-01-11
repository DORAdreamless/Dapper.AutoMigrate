using System;

namespace Tiantianquan.Common
{
    /// <summary>
    /// 提示性异常
    /// </summary>
    public class FriendlyException : Exception
    {
        public FriendlyException(string message) : base(message)
        {
        }
    }
}