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
    public class NavigationMenuDto 
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
        /// 上级菜单编码
        /// </summary>
        [Description("上级菜单编码")]
        public String   ParentId {get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public String   Name {get;set;}
        /// <summary>
        /// 显示名称
        /// </summary>
        [Description("显示名称")]
        public String   DisplayName {get;set;}
        /// <summary>
        /// 样式
        /// </summary>
        [Description("样式")]
        public String   Style {get;set;}
        /// <summary>
        /// 链接地址
        /// </summary>
        [Description("链接地址")]
        public String   LinkAddress {get;set;}
        /// <summary>
        /// 资源类别
        /// </summary>
        [Description("资源类别")]
        public String   ResourceType {get;set;}
        /// <summary>
        /// 其他属性
        /// </summary>
        [Description("其他属性")]
        public String   Attributes {get;set;}
        /// <summary>
        /// 构造函数
        /// </summary>
        public NavigationMenuDto()
        {
            Id = String.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ApplicationId = String.Empty;
            ParentId = String.Empty;
            Name = String.Empty;
            DisplayName = String.Empty;
            Style = String.Empty;
            LinkAddress = String.Empty;
            ResourceType = String.Empty;
            Attributes = String.Empty;
        }
    }
}

