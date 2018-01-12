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
    /// 用户
    /// </summary>
    [Description("用户")]
    public class ApplicationUser:BaseEntity<string>
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Description("账号")]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 密码哈希
        /// </summary>
        [Description("密码哈希")]
        public virtual string PasswordHash { get; set; }
        /// <summary>
        /// 密码盐值
        /// </summary>
        [Description("密码盐值")]
        public virtual string PasswordSalt { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Description("昵称")]
        public virtual string NickName { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        [Description("姓")]
        public virtual string FirstName { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [Description("名字")]
        public virtual string LastName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public virtual int Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Description("出生日期")]
        public virtual DateTime Birthday { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Description("年龄")]
        public virtual int Age { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [Description("手机")]
        public virtual string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱")]
        public virtual string Email { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Description("头像")]
        public virtual string HeadImageUrl { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Description("最后登录时间")]
        public virtual DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Description("最后登录IP")]
        public virtual string LastLoginIP { get; set; }

        /// <summary>
        /// 是否锁定 锁定后不允许登录
        /// </summary>
        [Description("是否锁定")]
        public virtual bool Locked { get; set; }

        /// <summary>
        /// 上次锁定时间
        /// </summary>
        [Description("上次锁定时间")]
        public virtual DateTime LockedTime { get; set; }

        /// <summary>
        /// 是否已登录 限制同一个用户只能登录一次
        /// </summary>
        [Description("是否已登录")]
        public virtual bool Logined { get; set; }
        /// <summary>
        /// 用户所属角色
        /// </summary>
        [Description("用户所属角色")]
        public virtual ISet<ApplicationRole> ApplicationRoles { get; set; }
    }
}
