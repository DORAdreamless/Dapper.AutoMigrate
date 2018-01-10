using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Privilege.Domain
{
   public class ApplicationRole
    {
        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual string UpdatedAt { get; set; }
    }
}
