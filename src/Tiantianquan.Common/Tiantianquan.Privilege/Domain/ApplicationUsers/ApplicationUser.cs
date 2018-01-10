using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Privilege.Domain
{
   public class ApplicationUser
    {
        public virtual string Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string PasswordSalt { get; set; }

        public virtual string NickName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        public virtual string OpenId { get; set; }

        public virtual string HeadImageUrl { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime UpdatedAt { get; set; }
    }
}
