using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Privilege.Domain
{
   public class NavigationMenu
    {
        public virtual string Id { get; set; }

        public virtual string ApplicationId { get; set; }

        public virtual string ParentId { get; set; }

        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Style { get; set; }

        public virtual string LinkAddress { get; set; }

        /// <summary>
        /// Button  Page 两类
        /// </summary>
        public virtual string ResourceType { get; set; }

        public virtual string Attributes { get; set; }
    }
}
