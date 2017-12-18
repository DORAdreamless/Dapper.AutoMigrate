using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.AutoMigrate.Fluent
{
   public class TableAttribute:Attribute
    {
        public string TableName { get; }

        public string TableDescription { get; set; }

        public string Schema { get; set; }

        
    }
}
