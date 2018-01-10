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
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 表备注
        /// </summary>
        public string TableDescription { get; set; }
        /// <summary>
        /// 构架
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 参数前缀
        /// </summary>
        public abstract string ParameterNamePrefix { get; }
        /// <summary>
        /// 前缀·
        /// </summary>

        public abstract string NamePrefix { get; }
        /// <summary>
        /// 后缀
        /// </summary>

        public abstract string NameSuffix { get; }

        public virtual string Engine => "MyISAM";

        public virtual string Charset => "utf8";

        public virtual string Collate => "utf8_bin";

        public List<PropertyMapper> PropertyMappers { get; }

        public PropertyInfo[] Properties { get; set; }

        public abstract bool HasTable();

       

        public abstract string GetPrimarySQL();


        public abstract bool IsTableExist();

        public abstract string GetCreateTableDDL();

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
