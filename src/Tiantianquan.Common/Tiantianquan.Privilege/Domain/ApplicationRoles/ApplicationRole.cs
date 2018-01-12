using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Domain;
using Tiantianquan.Common.Repositories;

namespace Tiantianquan.Privilege.Domain
{

    /// <summary>
    /// 角色
    /// </summary>
    [Description("角色")]
    public class ApplicationRole : BaseEntity<string>
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

        /// <summary>
        /// 角色有哪些用户
        /// </summary>
        [Description("角色有哪些用户")]
        public virtual ISet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
