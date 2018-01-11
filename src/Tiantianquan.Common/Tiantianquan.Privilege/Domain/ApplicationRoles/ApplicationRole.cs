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
    /// 角色
    /// </summary>
    [Description("角色")]
   public class ApplicationRole:BaseEntity<string>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        [Description("角色描述")]
        public virtual string Description { get; set; }

  
    }
}
