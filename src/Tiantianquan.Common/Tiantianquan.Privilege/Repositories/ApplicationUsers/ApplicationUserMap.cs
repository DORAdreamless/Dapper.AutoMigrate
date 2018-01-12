using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Domain;
using Tiantianquan.Common.Repositories;
using Tiantianquan.Privilege.Domain;

namespace Tiantianquan.Privilege.Repositories
{
    /// <summary>
    /// 用户
    /// </summary>
    public class ApplicationUserMap:BaseClassMap<ApplicationUser,string>
    {
        public ApplicationUserMap()
        {
            this.Table("SYS_ApplicationUser");
            this.Map(item => item.UserName);
            this.Map(item => item.PasswordHash);
            this.Map(item => item.PasswordSalt);
            this.Map(item => item.NickName);
            this.Map(item => item.FirstName);
            this.Map(item => item.LastName);
            this.Map(item => item.Sex);
            this.Map(item => item.Birthday);
            this.Map(item => item.Age);
            this.Map(item => item.Phone);
            this.Map(item => item.Email);
            this.Map(item => item.HeadImageUrl);
            this.Map(item => item.LastLoginTime);
            this.Map(item => item.LastLoginIP);
            this.Map(item => item.Locked);
            this.Map(item => item.LockedTime);
            this.Map(item => item.Logined);
            this.HasManyToMany(x => x.ApplicationRoles).ParentKeyColumn("ApplicationUserId").ChildKeyColumn("ApplicationRoleId").Table("SYS_ApplicationUserRoles");
        }
    }
}
