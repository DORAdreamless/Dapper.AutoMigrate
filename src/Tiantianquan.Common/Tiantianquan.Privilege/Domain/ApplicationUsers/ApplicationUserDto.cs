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
    public class ApplicationUserDto 
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
        /// 账号
        /// </summary>
        [Description("账号")]
        public String   UserName {get;set;}
        /// <summary>
        /// 密码哈希
        /// </summary>
        [Description("密码哈希")]
        public String   PasswordHash {get;set;}
        /// <summary>
        /// 密码盐值
        /// </summary>
        [Description("密码盐值")]
        public String   PasswordSalt {get;set;}
        /// <summary>
        /// 昵称
        /// </summary>
        [Description("昵称")]
        public String   NickName {get;set;}
        /// <summary>
        /// 姓
        /// </summary>
        [Description("姓")]
        public String   FirstName {get;set;}
        /// <summary>
        /// 名字
        /// </summary>
        [Description("名字")]
        public String   LastName {get;set;}
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public Int32   Sex {get;set;}
        /// <summary>
        /// 出生日期
        /// </summary>
        [Description("出生日期")]
        public DateTime   Birthday {get;set;}
        /// <summary>
        /// 年龄
        /// </summary>
        [Description("年龄")]
        public Int32   Age {get;set;}
        /// <summary>
        /// 手机
        /// </summary>
        [Description("手机")]
        public String   Phone {get;set;}
        /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱")]
        public String   Email {get;set;}
        /// <summary>
        /// 头像
        /// </summary>
        [Description("头像")]
        public String   HeadImageUrl {get;set;}
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Description("最后登录时间")]
        public DateTime   LastLoginTime {get;set;}
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Description("最后登录IP")]
        public String   LastLoginIP {get;set;}
        /// <summary>
        /// 是否锁定
        /// </summary>
        [Description("是否锁定")]
        public Boolean   Locked {get;set;}
        /// <summary>
        /// 上次锁定时间
        /// </summary>
        [Description("上次锁定时间")]
        public DateTime   LockedTime {get;set;}
        /// <summary>
        /// 是否已登录
        /// </summary>
        [Description("是否已登录")]
        public Boolean   Logined {get;set;}
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApplicationUserDto()
        {
            Id = String.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            UserName = String.Empty;
            PasswordHash = String.Empty;
            PasswordSalt = String.Empty;
            NickName = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Birthday = DateTime.Now;
            Phone = String.Empty;
            Email = String.Empty;
            HeadImageUrl = String.Empty;
            LastLoginTime = DateTime.Now;
            LastLoginIP = String.Empty;
            LockedTime = DateTime.Now;
        }
    }
}

