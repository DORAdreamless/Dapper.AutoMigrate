using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.AutoMigrate.Mysql
{
    public class MySqlEntityMapper : EntityMapper
    {
        public MySqlEntityMapper(Type entityMapperType) : base(entityMapperType)
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
            this.PropertyMappers.ForEach(propertyMapper =>
            {
                propertyScript.Add(propertyMapper.GetCreateColumnSQL());
            });
            propertyScript.Add(this.GetPrimarySQL());
            propertyScript.AddRange(this.GetCreateTableIndexSQL());
            builder.Append(string.Join(",\n", propertyScript));
            builder.AppendLine();
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
            builder.Append(" PRIMARY KEY(");
            List<PropertyMapper> primaryKeyFields = this.PropertyMappers.Where(item => item.ParmaryKey).ToList();
            List<string> prumaryKeyColumns = primaryKeyFields.Select(item => item.EntityMapper.NamePrefix + item.ColumnName + item.EntityMapper.NameSuffix).ToList();
            builder.Append(string.Join(",", prumaryKeyColumns));
            builder.Append(")");
            return builder.ToString();
        }

        private string[] GetCreateTableIndexSQL()
        {
            var idxProperties = this.PropertyMappers.Where(item => item.Index).ToList();
            string[] idxSqls = new string[idxProperties.Count()];
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < idxProperties.Count(); i++)
            {
                var idx = idxProperties[i];
                builder.Append(" KEY");
                builder.Append(" ").Append(this.NamePrefix).AppendFormat("idx_{0}_{1}", this.TableName, idx.ColumnName).Append(this.NameSuffix);
                builder.Append(" (").Append(this.NamePrefix).Append(idx.ColumnName).Append(this.NameSuffix).Append(")");
                idxSqls[i] = builder.ToString();
            }
            return idxSqls;
        }

        public override bool IsTableExist()
        {
            throw new NotImplementedException();
        }
    }
}
