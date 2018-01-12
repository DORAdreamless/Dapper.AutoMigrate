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
    public class NavigationMenuMap: BaseClassMap<NavigationMenu, string>
    {
       

        public NavigationMenuMap()
        {
            this.Table("SYS_NavigationMenu");
            this.Map(item => item.ApplicationId);
            this.Map(item => item.ParentId);
            this.Map(item => item.Name);
            this.Map(item => item.DisplayName);
            this.Map(item => item.Style);
            this.Map(item => item.LinkAddress);
            this.Map(item => item.ResourceType);
            this.Map(item => item.Attributes);

            Engine.AddForeignKey<NavigationMenu, Tiantianquan.Privilege.Domain.Application>(item => item.ApplicationId, item => item.Id);
            Engine.AddForeignKey<NavigationMenu, NavigationMenu>(item => item.ParentId, item => item.Id);
        }
    }
}
