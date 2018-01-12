using System;
using System.ComponentModel;
using FluentValidation;
using FluentValidation.Attributes;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Privilege.Domain
{
    /// <summary>
    /// 角色
    /// </summary>
    [Description("角色")]
    public class ApplicationRoleDto 
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
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public String   Name {get;set;}
        /// <summary>
        /// 角色描述
        /// </summary>
        [Description("角色描述")]
        public String   Description {get;set;}
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApplicationRoleDto()
        {
            Id = String.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Name = String.Empty;
            Description = String.Empty;
        }
    }
}

