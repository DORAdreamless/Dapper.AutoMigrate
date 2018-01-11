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
    public class NavigationMenu: BaseEntity<string>
    {
        /// <summary>
        /// 应用编码
        /// </summary>
        [Description("应用编码")]
        public virtual string ApplicationId { get; set; }
        /// <summary>
        /// 上级菜单编码
        /// </summary>
        [Description("上级菜单编码")]
        public virtual string ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [Description("显示名称")]
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// 样式,图标或者class
        /// </summary>
        [Description("样式")]
        public virtual string Style { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [Description("链接地址")]
        public virtual string LinkAddress { get; set; }

        /// <summary>
        /// 资源类别，Page,Button
        /// </summary>
        [Description("资源类别")]
        public virtual string ResourceType { get; set; }
        /// <summary>
        /// 其他属性
        /// </summary>
        [Description("其他属性")]
        public virtual string Attributes { get; set; }
    }
}
