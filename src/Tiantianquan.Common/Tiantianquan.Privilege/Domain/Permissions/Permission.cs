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
    /// 导航菜单
    /// </summary>
    [Description("导航菜单")]
    public class Permission:BaseEntity<string>
    {

        /// <summary>
        /// 应用编码
        /// </summary>
        [Description("应用编码")]
        public virtual string ApplicationId { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        [Description("用户编码")]
        public virtual string ApplicationUserId { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        [Description("角色编码")]
        public virtual string ApplicationRoleId { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Description("菜单编码")]
        public virtual string NavigationMenuId { get; set; }
        /// <summary>
        /// 是否授权
        /// </summary>
        [Description("是否授权")]
        public virtual bool Granted { get; set; }
        /// <summary>
        /// 授权用户编码
        /// </summary>
        [Description("授权用户编码")]
        public virtual string CreatedUserId { get; set; }

        

    }
}
