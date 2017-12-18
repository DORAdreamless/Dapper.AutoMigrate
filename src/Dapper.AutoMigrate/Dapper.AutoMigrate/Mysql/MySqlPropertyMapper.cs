using System;
using System.Reflection;
using System.Text;

namespace Dapper.AutoMigrate.Mysql
{
    public class MySqlPropertyMapper : PropertyMapper
    {
        public MySqlPropertyMapper(EntityMapper entityMapper, PropertyInfo property) : base(entityMapper, property)
        {
        }



        public override string GetAlterColumnSQL()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" alter ").Append(this.EntityMapper.NamePrefix).Append(this.EntityMapper.TableName).Append(this.EntityMapper.NameSuffix);
            builder.Append(this.EntityMapper.NamePrefix).Append(this.ColumnName).Append(this.EntityMapper.NameSuffix).Append(" ").Append(this.Type);
            if (this.NotNull)
            {
                builder.Append(" not null");
            }
            if (string.IsNullOrWhiteSpace(this.Default))
            {
                builder.Append(" default null");
            }
            else
            {
                builder.Append(" default ").Append(this.Default);
            }
            //注释
            return builder.ToString();
        }

        public override string GetCreateColumnSQL()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.EntityMapper.NamePrefix).Append(this.ColumnName).Append(this.EntityMapper.NameSuffix).Append(" ").Append(this.Type);
            if (this.NotNull)
            {
                builder.Append(" not null");
            }
            if (string.IsNullOrWhiteSpace(this.Default))
            {
                builder.Append(" default null");
            }
            else
            {
                builder.Append(" default ").Append(this.Default);
            }
            builder.Append(",");
            return builder.ToString();
        }

        public override string GetDropColumnSQL()
        {
            throw new NotImplementedException();
        }
    }
}
