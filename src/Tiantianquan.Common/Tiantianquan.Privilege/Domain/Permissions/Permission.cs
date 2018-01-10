using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Privilege.Domain
{
   public class Permission
    {
        public virtual string Id { get; set; }

        public virtual string ApplicationId { get; set; }

        public virtual string ApplicationUserId { get; set; }

        public virtual string ApplicationRoleId { get; set; }

        public virtual string NavicationMenuId { get; set; }

        public virtual bool Granted { get; set; }

        public virtual string CreatedUserId { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime UpdatedAt { get; set; }
    }
}
