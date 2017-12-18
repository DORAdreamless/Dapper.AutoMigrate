using Dapper.AutoMigrate.Fluent;
using Dapper.AutoMigrate.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Dapper.AutoMigrate
{
    public abstract class EntityMapper
    {
        public string TableName { get; set; }

        public string TableDescription { get; set; }

        public string Schema { get; set; }

        public List<PropertyMapper> PropertyMappers { get; }

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

        public  string GetSyncScripts(StreamWriter streamWriter)
        {
            StringBuilder builder = new StringBuilder();
            //1、建表语句
            if (this.IsTableExist())
            {

            }
            //2、列新增语句

            //3、索引变更语句

            //4、唯一索引变更语句

            //5、外键语句

            //6、注释语句
            return builder.ToString();
        }

        public EntityMapper(Type entityMapperType)
        {
            this.PropertyMappers = new List<PropertyMapper>();

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
