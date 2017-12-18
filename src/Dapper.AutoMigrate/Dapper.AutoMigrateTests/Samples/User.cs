using Dapper.AutoMigrate.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.AutoMigrate.Tests.Samples
{
    [Table()]
    public class User : DbEntity
    {
        [Column()]
        public string NickName { get; set; }

        [Column(Unique = true, Index = true)]
        public string UserName { get; set; }
        [Column()]
        public string PasswordSalt { get; set; }
        [Column()]
        public string PasswordHash { get; set; }
        [Column()]
        public string HeadImageUrl { get; set; }
        [Column()]
        public DateTime? Birthday { get; set; }
        [Column()]
        public string Phone { get; set; }
        [Column()]
        public string Email { get; set; }

    }

}
