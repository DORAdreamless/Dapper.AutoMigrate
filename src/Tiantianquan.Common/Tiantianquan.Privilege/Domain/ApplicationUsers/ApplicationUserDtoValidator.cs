using System;
using System.ComponentModel;
using FluentValidation;
using FluentValidation.Attributes;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Privilege.Domain
{
    /// <summary>
    /// 用户
    /// </summary>
    [Description("用户")]
    public class ApplicationUserDtoValidator:AbstractValidator<ApplicationUserDto> 
    {
      
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApplicationUserDtoValidator()
        {
            RuleFor(item => item.Id).NotNull().WithMessage("编号不能为空。");
            RuleFor(item => item.Id).NotEmpty().WithMessage("编号不能为空。");
            RuleFor(item => item.Id).MinimumLength(10).WithMessage("编号最少10个字。");
            RuleFor(item => item.Id).MaximumLength(255).WithMessage("编号最多255个字。");
              
            RuleFor(item => item.CreatedAt).NotNull().WithMessage("创建时间不能为空。");
              
            RuleFor(item => item.UpdatedAt).NotNull().WithMessage("更新时间不能为空。");
              
            RuleFor(item => item.UserName).NotNull().WithMessage("账号不能为空。");
            RuleFor(item => item.UserName).NotEmpty().WithMessage("账号不能为空。");
            RuleFor(item => item.UserName).MinimumLength(10).WithMessage("账号最少10个字。");
            RuleFor(item => item.UserName).MaximumLength(255).WithMessage("账号最多255个字。");
              
            RuleFor(item => item.PasswordHash).NotNull().WithMessage("密码哈希不能为空。");
            RuleFor(item => item.PasswordHash).NotEmpty().WithMessage("密码哈希不能为空。");
            RuleFor(item => item.PasswordHash).MinimumLength(10).WithMessage("密码哈希最少10个字。");
            RuleFor(item => item.PasswordHash).MaximumLength(255).WithMessage("密码哈希最多255个字。");
              
            RuleFor(item => item.PasswordSalt).NotNull().WithMessage("密码盐值不能为空。");
            RuleFor(item => item.PasswordSalt).NotEmpty().WithMessage("密码盐值不能为空。");
            RuleFor(item => item.PasswordSalt).MinimumLength(10).WithMessage("密码盐值最少10个字。");
            RuleFor(item => item.PasswordSalt).MaximumLength(255).WithMessage("密码盐值最多255个字。");
              
            RuleFor(item => item.NickName).NotNull().WithMessage("昵称不能为空。");
            RuleFor(item => item.NickName).NotEmpty().WithMessage("昵称不能为空。");
            RuleFor(item => item.NickName).MinimumLength(10).WithMessage("昵称最少10个字。");
            RuleFor(item => item.NickName).MaximumLength(255).WithMessage("昵称最多255个字。");
              
            RuleFor(item => item.FirstName).NotNull().WithMessage("姓不能为空。");
            RuleFor(item => item.FirstName).NotEmpty().WithMessage("姓不能为空。");
            RuleFor(item => item.FirstName).MinimumLength(10).WithMessage("姓最少10个字。");
            RuleFor(item => item.FirstName).MaximumLength(255).WithMessage("姓最多255个字。");
              
            RuleFor(item => item.LastName).NotNull().WithMessage("名字不能为空。");
            RuleFor(item => item.LastName).NotEmpty().WithMessage("名字不能为空。");
            RuleFor(item => item.LastName).MinimumLength(10).WithMessage("名字最少10个字。");
            RuleFor(item => item.LastName).MaximumLength(255).WithMessage("名字最多255个字。");
              
            RuleFor(item => item.Sex).NotNull().WithMessage("性别不能为空。");
              
            RuleFor(item => item.Birthday).NotNull().WithMessage("出生日期不能为空。");
              
            RuleFor(item => item.Age).NotNull().WithMessage("年龄不能为空。");
              
            RuleFor(item => item.Phone).NotNull().WithMessage("手机不能为空。");
            RuleFor(item => item.Phone).NotEmpty().WithMessage("手机不能为空。");
            RuleFor(item => item.Phone).MinimumLength(10).WithMessage("手机最少10个字。");
            RuleFor(item => item.Phone).MaximumLength(255).WithMessage("手机最多255个字。");
              
            RuleFor(item => item.Email).NotNull().WithMessage("邮箱不能为空。");
            RuleFor(item => item.Email).NotEmpty().WithMessage("邮箱不能为空。");
            RuleFor(item => item.Email).MinimumLength(10).WithMessage("邮箱最少10个字。");
            RuleFor(item => item.Email).MaximumLength(255).WithMessage("邮箱最多255个字。");
              
            RuleFor(item => item.HeadImageUrl).NotNull().WithMessage("头像不能为空。");
            RuleFor(item => item.HeadImageUrl).NotEmpty().WithMessage("头像不能为空。");
            RuleFor(item => item.HeadImageUrl).MinimumLength(10).WithMessage("头像最少10个字。");
            RuleFor(item => item.HeadImageUrl).MaximumLength(255).WithMessage("头像最多255个字。");
              
            RuleFor(item => item.LastLoginTime).NotNull().WithMessage("最后登录时间不能为空。");
              
            RuleFor(item => item.LastLoginIP).NotNull().WithMessage("最后登录IP不能为空。");
            RuleFor(item => item.LastLoginIP).NotEmpty().WithMessage("最后登录IP不能为空。");
            RuleFor(item => item.LastLoginIP).MinimumLength(10).WithMessage("最后登录IP最少10个字。");
            RuleFor(item => item.LastLoginIP).MaximumLength(255).WithMessage("最后登录IP最多255个字。");
              
            RuleFor(item => item.Locked).NotNull().WithMessage("是否锁定不能为空。");
              
            RuleFor(item => item.LockedTime).NotNull().WithMessage("上次锁定时间不能为空。");
              
            RuleFor(item => item.Logined).NotNull().WithMessage("是否已登录不能为空。");
              
        }
    }
}

