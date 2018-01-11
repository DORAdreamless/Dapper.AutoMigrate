using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Privilege.Domain
{
    /// <summary>
    /// 应用
    /// </summary>
    [Description("应用")]
    public class Application: BaseEntity<string>
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        [Description("应用名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 应用描述
        /// </summary>
        [Description("应用描述")]
        public virtual string Description { get; set; }
    }
}
