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

    public class ApplicationMap: BaseClassMap<Tiantianquan.Privilege.Domain.Application, string>
    {
        public ApplicationMap()
        {
            this.Table("SYS_Application");
            this.Map(item => item.Name);
            this.Map(item => item.Description);
        }
    }
}
