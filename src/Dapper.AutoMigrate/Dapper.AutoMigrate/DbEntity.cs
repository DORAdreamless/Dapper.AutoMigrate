using Dapper.AutoMigrate;
using Dapper.AutoMigrate.Fluent;
using System;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Reflection;

namespace Dapper.AutoMigrate
{
   

 
    public class DbEntity:IDbEntity
    {
        [PrimaryKey]
        [Column()]
        public Guid Id { get; set; }
        [Column()]
        public DateTime CreatedAt { get; set; }
        [Column()]
        public DateTime UpdatedAt { get; set; }
        [Column()]
        public DateTime DeletedAt { get; set; }
    }

   

}
