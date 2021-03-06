﻿using System;
using System.ComponentModel;
using FluentValidation;
using FluentValidation.Attributes;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Privilege.Domain
{
    /// <summary>
    /// 应用
    /// </summary>
    [Description("应用")]
    public class ApplicationDtoValidator:AbstractValidator<ApplicationDto> 
    {
      
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApplicationDtoValidator()
        {
            RuleFor(item => item.Id).NotNull().WithMessage("编号不能为空。");
            RuleFor(item => item.Id).NotEmpty().WithMessage("编号不能为空。");
            RuleFor(item => item.Id).MinimumLength(10).WithMessage("编号最少10个字。");
            RuleFor(item => item.Id).MaximumLength(255).WithMessage("编号最多255个字。");
              
            RuleFor(item => item.CreatedAt).NotNull().WithMessage("创建时间不能为空。");
              
            RuleFor(item => item.UpdatedAt).NotNull().WithMessage("更新时间不能为空。");
              
            RuleFor(item => item.Name).NotNull().WithMessage("应用名称不能为空。");
            RuleFor(item => item.Name).NotEmpty().WithMessage("应用名称不能为空。");
            RuleFor(item => item.Name).MinimumLength(10).WithMessage("应用名称最少10个字。");
            RuleFor(item => item.Name).MaximumLength(255).WithMessage("应用名称最多255个字。");
              
            RuleFor(item => item.Description).NotNull().WithMessage("应用描述不能为空。");
            RuleFor(item => item.Description).NotEmpty().WithMessage("应用描述不能为空。");
            RuleFor(item => item.Description).MinimumLength(10).WithMessage("应用描述最少10个字。");
            RuleFor(item => item.Description).MaximumLength(255).WithMessage("应用描述最多255个字。");
              
        }
    }
}

