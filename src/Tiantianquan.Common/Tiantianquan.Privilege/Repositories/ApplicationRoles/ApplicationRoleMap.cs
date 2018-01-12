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
    
    public class ApplicationRoleMap : BaseClassMap<ApplicationRole, string>
    {
        public ApplicationRoleMap()
        {
            this.Table("SYS_ApplicationRole");
            this.Map(item => item.Name);
            this.Map(item => item.Description);

            this.HasManyToMany(x => x.ApplicationUsers).ParentKeyColumn("ApplicationRoleId").ChildKeyColumn("ApplicationUserId").Table("SYS_ApplicationUserRoles");
        }
    }
}
