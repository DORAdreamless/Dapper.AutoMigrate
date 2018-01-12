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
    /// 导航菜单
    /// </summary>
    [Description("导航菜单")]
    public class PermissionMap: BaseClassMap<Permission,string>
    {
        

        public PermissionMap()
        {
            this.Table("SYS_Permission");
            this.Map(item => item.ApplicationId);
            this.Map(item => item.ApplicationRoleId);
            this.Map(item => item.ApplicationUserId);
            this.Map(item => item.NavigationMenuId);
            this.Map(item => item.Granted);
            this.Map(item => item.CreatedUserId).Nullable();

            Engine.AddForeignKey<Permission, Application>(item => item.ApplicationId, item => item.Id);
            Engine.AddForeignKey<Permission, ApplicationRole>(item => item.ApplicationRoleId, item => item.Id);
            Engine.AddForeignKey<Permission, ApplicationUser>(item => item.ApplicationUserId, item => item.Id);
            Engine.AddForeignKey<Permission, NavigationMenu>(item => item.NavigationMenuId, item => item.Id);
            Engine.AddForeignKey<Permission, ApplicationUser>(item => item.CreatedUserId, item => item.Id);
        }

    }
}
