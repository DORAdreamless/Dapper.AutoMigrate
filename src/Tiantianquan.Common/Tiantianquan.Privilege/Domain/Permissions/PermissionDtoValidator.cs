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
    public class PermissionDtoValidator:AbstractValidator<PermissionDto> 
    {
      
        /// <summary>
        /// 构造函数
        /// </summary>
        public PermissionDtoValidator()
        {
            RuleFor(item => item.Id).NotNull().WithMessage("编号不能为空。");
            RuleFor(item => item.Id).NotEmpty().WithMessage("编号不能为空。");
            RuleFor(item => item.Id).MinimumLength(10).WithMessage("编号最少10个字。");
            RuleFor(item => item.Id).MaximumLength(255).WithMessage("编号最多255个字。");
              
            RuleFor(item => item.CreatedAt).NotNull().WithMessage("创建时间不能为空。");
              
            RuleFor(item => item.UpdatedAt).NotNull().WithMessage("更新时间不能为空。");
              
            RuleFor(item => item.ApplicationId).NotNull().WithMessage("应用编码不能为空。");
            RuleFor(item => item.ApplicationId).NotEmpty().WithMessage("应用编码不能为空。");
            RuleFor(item => item.ApplicationId).MinimumLength(10).WithMessage("应用编码最少10个字。");
            RuleFor(item => item.ApplicationId).MaximumLength(255).WithMessage("应用编码最多255个字。");
              
            RuleFor(item => item.ApplicationRoleId).NotNull().WithMessage("角色编码不能为空。");
            RuleFor(item => item.ApplicationRoleId).NotEmpty().WithMessage("角色编码不能为空。");
            RuleFor(item => item.ApplicationRoleId).MinimumLength(10).WithMessage("角色编码最少10个字。");
            RuleFor(item => item.ApplicationRoleId).MaximumLength(255).WithMessage("角色编码最多255个字。");
              
            RuleFor(item => item.ApplicationUserId).NotNull().WithMessage("用户编码不能为空。");
            RuleFor(item => item.ApplicationUserId).NotEmpty().WithMessage("用户编码不能为空。");
            RuleFor(item => item.ApplicationUserId).MinimumLength(10).WithMessage("用户编码最少10个字。");
            RuleFor(item => item.ApplicationUserId).MaximumLength(255).WithMessage("用户编码最多255个字。");
              
            RuleFor(item => item.NavigationMenuId).NotNull().WithMessage("菜单编码不能为空。");
            RuleFor(item => item.NavigationMenuId).NotEmpty().WithMessage("菜单编码不能为空。");
            RuleFor(item => item.NavigationMenuId).MinimumLength(10).WithMessage("菜单编码最少10个字。");
            RuleFor(item => item.NavigationMenuId).MaximumLength(255).WithMessage("菜单编码最多255个字。");
              
            RuleFor(item => item.Granted).NotNull().WithMessage("是否授权不能为空。");
              
            RuleFor(item => item.CreatedUserId).NotNull().WithMessage("授权用户编码不能为空。");
            RuleFor(item => item.CreatedUserId).NotEmpty().WithMessage("授权用户编码不能为空。");
            RuleFor(item => item.CreatedUserId).MinimumLength(10).WithMessage("授权用户编码最少10个字。");
            RuleFor(item => item.CreatedUserId).MaximumLength(255).WithMessage("授权用户编码最多255个字。");
              
        }
    }
}

