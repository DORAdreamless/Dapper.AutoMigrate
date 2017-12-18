using System;

namespace Dapper.AutoMigrate.Fluent
{
    public class PrimaryKeyAttribute: Attribute
    {
       public bool Auto { get; set; }
    }
}
