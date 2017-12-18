using System;

namespace Dapper.AutoMigrate.Mysql
{
    public class MssqlEntityMapper : EntityMapper
    {
        public MssqlEntityMapper(Type entityMapperType) : base(entityMapperType)
        {
        }

        public override string ParameterNamePrefix => "@";

        public override string NamePrefix => "[";

        public override string NameSuffix => "]";

        public override string GetCreateTableDDL()
        {
            throw new NotImplementedException();
        }

        public override string GetPrimarySQL()
        {
            throw new NotImplementedException();
        }

        public override bool IsTableExist()
        {
            throw new NotImplementedException();
        }
    }
}
