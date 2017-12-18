using Dapper.AutoMigrate.Fluent;
using Dapper.AutoMigrate.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dapper.AutoMigrate
{
    public abstract class EntityMapper
    {
        public string TableName { get; set; }

        public string TableDescription { get; set; }

        public string Schema { get; set; }

        public List<PropertyMapper> Fields { get; set; }

        public PropertyInfo[] Properties { get; set; }

        public abstract bool IsTableExist();

        public abstract string GetCreateTableDDL();

        public abstract string ParameterNamePrefix { get; }

        public abstract string NamePrefix { get; }

        public abstract string NameSuffix { get; }

        public virtual string Engine => "MyISAM";

        public virtual string Charset => "utf8";

        public virtual string Collate => "utf8_bin";

        public abstract string GetPrimarySQL();

        public EntityMapper(Type entityMapperType)
        {
            TableAttribute tableAttribute = entityMapperType.GetCustomAttribute<TableAttribute>();
            this.TableName = tableAttribute.TableName;
            if (string.IsNullOrWhiteSpace(this.TableName))
            {
                this.TableName = StringUtils.GetSnackName(entityMapperType.Name);
            }
            this.TableDescription = tableAttribute.TableDescription;
            if (string.IsNullOrWhiteSpace(this.TableDescription))
            {
                this.TableDescription = this.TableName;
            }
        }
    }
}
