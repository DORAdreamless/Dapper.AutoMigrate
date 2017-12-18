using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.AutoMigrate.Mysql
{
    public class MysqlEntityMapper : EntityMapper
    {
        public MysqlEntityMapper(Type entityMapperType) : base(entityMapperType)
        {
        }

        public override string ParameterNamePrefix => "?";

        public override string NamePrefix => "`";

        public override string NameSuffix => "`";

        public override string GetCreateTableDDL()
        {
            StringBuilder builder = new StringBuilder();
            List<string> propertyScript = new List<string>();
            builder.Append("CREATE TABLE ").Append(this.NamePrefix).Append(this.TableName).Append(this.NameSuffix).Append("(").AppendLine();
            this.Fields.ForEach(propertyMapper =>
            {
                propertyScript.Add(propertyMapper.GetCreateColumnSQL());
            });
            propertyScript.Add(this.GetPrimarySQL());
            builder.Append(string.Join(",\n", propertyScript));
            builder.Append(")");
            builder.Append(" ENGINE=").Append(this.Engine)
            .Append(" DEFAULT CHARSET=").Append(this.Charset)
            .Append(" COLLATE=").Append(this.Collate)
            .Append(";");
            return builder.ToString();
        }

        public override string GetPrimarySQL()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("PRIMARY KEY(");
            List<PropertyMapper> primaryKeyFields = this.Fields.Where(item => item.ParmaryKey).ToList();
            List<string> prumaryKeyColumns = primaryKeyFields.Select(item => item.EntityMapper.NamePrefix + item.ColumnName + item.EntityMapper.NameSuffix).ToList();
            builder.Append(string.Join(",", prumaryKeyColumns));
            builder.Append(")");
            return builder.ToString();
        }



        public override bool IsTableExist()
        {
            throw new NotImplementedException();
        }
    }
}
