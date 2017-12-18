using System;
using System.Reflection;

namespace Dapper.AutoMigrate.Mysql
{
    public class MsSqlPropertyMapper : PropertyMapper
    {
        public MsSqlPropertyMapper(EntityMapper entityMapper, PropertyInfo property) : base(entityMapper, property)
        {
        }

        public override string GetAlterColumnSQL()
        {
            throw new NotImplementedException();
        }

        public override string GetCreateColumnSQL()
        {
            throw new NotImplementedException();
        }

        public override string GetDataType()
        {
            throw new NotImplementedException();
        }

        public override string GetDropColumnSQL()
        {
            throw new NotImplementedException();
        }
    }
}
