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
    public class NavigationMenuDtoValidator:AbstractValidator<NavigationMenuDto> 
    {
      
        /// <summary>
        /// 构造函数
        /// </summary>
        public NavigationMenuDtoValidator()
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
              
            RuleFor(item => item.ParentId).NotNull().WithMessage("上级菜单编码不能为空。");
            RuleFor(item => item.ParentId).NotEmpty().WithMessage("上级菜单编码不能为空。");
            RuleFor(item => item.ParentId).MinimumLength(10).WithMessage("上级菜单编码最少10个字。");
            RuleFor(item => item.ParentId).MaximumLength(255).WithMessage("上级菜单编码最多255个字。");
              
            RuleFor(item => item.Name).NotNull().WithMessage("名称不能为空。");
            RuleFor(item => item.Name).NotEmpty().WithMessage("名称不能为空。");
            RuleFor(item => item.Name).MinimumLength(10).WithMessage("名称最少10个字。");
            RuleFor(item => item.Name).MaximumLength(255).WithMessage("名称最多255个字。");
              
            RuleFor(item => item.DisplayName).NotNull().WithMessage("显示名称不能为空。");
            RuleFor(item => item.DisplayName).NotEmpty().WithMessage("显示名称不能为空。");
            RuleFor(item => item.DisplayName).MinimumLength(10).WithMessage("显示名称最少10个字。");
            RuleFor(item => item.DisplayName).MaximumLength(255).WithMessage("显示名称最多255个字。");
              
            RuleFor(item => item.Style).NotNull().WithMessage("样式不能为空。");
            RuleFor(item => item.Style).NotEmpty().WithMessage("样式不能为空。");
            RuleFor(item => item.Style).MinimumLength(10).WithMessage("样式最少10个字。");
            RuleFor(item => item.Style).MaximumLength(255).WithMessage("样式最多255个字。");
              
            RuleFor(item => item.LinkAddress).NotNull().WithMessage("链接地址不能为空。");
            RuleFor(item => item.LinkAddress).NotEmpty().WithMessage("链接地址不能为空。");
            RuleFor(item => item.LinkAddress).MinimumLength(10).WithMessage("链接地址最少10个字。");
            RuleFor(item => item.LinkAddress).MaximumLength(255).WithMessage("链接地址最多255个字。");
              
            RuleFor(item => item.ResourceType).NotNull().WithMessage("资源类别不能为空。");
            RuleFor(item => item.ResourceType).NotEmpty().WithMessage("资源类别不能为空。");
            RuleFor(item => item.ResourceType).MinimumLength(10).WithMessage("资源类别最少10个字。");
            RuleFor(item => item.ResourceType).MaximumLength(255).WithMessage("资源类别最多255个字。");
              
            RuleFor(item => item.Attributes).NotNull().WithMessage("其他属性不能为空。");
            RuleFor(item => item.Attributes).NotEmpty().WithMessage("其他属性不能为空。");
            RuleFor(item => item.Attributes).MinimumLength(10).WithMessage("其他属性最少10个字。");
            RuleFor(item => item.Attributes).MaximumLength(255).WithMessage("其他属性最多255个字。");
              
        }
    }
}

