using System;
using System.ComponentModel;
using FluentValidation;
using FluentValidation.Attributes;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Privilege.Domain
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    [Description("导航菜单")]
    public class PermissionDto 
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public String   Id {get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime   CreatedAt {get;set;}
        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        public DateTime   UpdatedAt {get;set;}
        /// <summary>
        /// 应用编码
        /// </summary>
        [Description("应用编码")]
        public String   ApplicationId {get;set;}
        /// <summary>
        /// 角色编码
        /// </summary>
        [Description("角色编码")]
        public String   ApplicationRoleId {get;set;}
        /// <summary>
        /// 用户编码
        /// </summary>
        [Description("用户编码")]
        public String   ApplicationUserId {get;set;}
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Description("菜单编码")]
        public String   NavigationMenuId {get;set;}
        /// <summary>
        /// 是否授权
        /// </summary>
        [Description("是否授权")]
        public Boolean   Granted {get;set;}
        /// <summary>
        /// 授权用户编码
        /// </summary>
        [Description("授权用户编码")]
        public String   CreatedUserId {get;set;}
        /// <summary>
        /// 构造函数
        /// </summary>
        public PermissionDto()
        {
            Id = String.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ApplicationId = String.Empty;
            ApplicationRoleId = String.Empty;
            ApplicationUserId = String.Empty;
            NavigationMenuId = String.Empty;
            CreatedUserId = String.Empty;
        }
    }
}

