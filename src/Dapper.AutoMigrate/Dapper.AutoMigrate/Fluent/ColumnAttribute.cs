using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.AutoMigrate.Fluent
{
    public  class ColumnAttribute:Attribute
    {
        public string ColumnName { get; set; }


        public string Type { get; set; }

        public bool Unique { get; set; }

        public bool Index { get; set; }

        public int Size { get; set; }


    }
}
