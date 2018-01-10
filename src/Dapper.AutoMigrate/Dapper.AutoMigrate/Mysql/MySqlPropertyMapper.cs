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
            builder.Append(this.EntityMapper.NamePrefix).Append(this.ColumnName).Append(this.EntityMapper.NameSuffix).Append(" ").Append(this.DbType);
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
            builder.Append(this.EntityMapper.NamePrefix).Append(this.ColumnName).Append(this.EntityMapper.NameSuffix).Append(" ").Append(this.DbType);
            if (this.NotNull||this.ParmaryKey||this.Unique||this.Index)
            {
                builder.Append(" not null");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.Default))
                {
                    builder.Append(" default null");
                }
            }
            if (this.Unique)
            {
                builder.Append(" unique ");
            }
            if (!string.IsNullOrWhiteSpace(this.Default))
            {
                builder.Append(" default ").Append(this.Default);
            }
            builder.AppendFormat(" COMMENT '{0}'",this.ColumnDescription);
            return builder.ToString();
        }

        public override string GetDataType()
        {
            if (string.IsNullOrWhiteSpace(this.DbType))
            {
                switch (this.PropertyType.FullName)
                {
                    case "System.Boolean":
                        this.DbType = "bit";
                        break;
                    case "System.SByte":
                    case "System.Byte":
                        this.DbType = "smallint";
                        break;
                    case "System.Char":
                        this.DbType = "char(1)";
                        break;
                    case "System.DateTime":
                        this.DbType = "datetime";
                        break;
                    case "System.Decimal":
                        this.DbType = "decimal(18,4)";
                        break;
                    case "System.Double":
                        this.DbType = "double";
                        break;
                    case "System.Int16":
                    case "System.UInt16":
                        this.DbType = "smallint";
                        break;
                    case "System.Int32":
                    case "System.UInt32":
                        this.DbType = "int";
                        break;
                    case "System.Int64":
                    case "System.UInt64":
                        this.DbType = "bigint";
                        break;
                    case "System.Guid":
                        this.DbType = "char(36)";
                        break;
                    case "System.Single":
                        this.DbType = "decimal(18,7)";
                        break;
                    case "System.String":
                        if (this.Size > 4000)
                        {
                            this.DbType = string.Format("mediumtext({0})", this.Size);
                        }
                        else if (this.Size > 0 && this.Size < 4000)
                        {
                            this.DbType = string.Format("varchar({0})", this.Size);
                        }
                        else
                        {
                            this.DbType = string.Format("varchar(255)");
                        }
                        break;
                    default:
                        this.DbType = "mediumtext(65535)";
                        break;
                }
            }
            return this.DbType;
        }

        public override string GetDropColumnSQL()
        {
            throw new NotImplementedException();
        }

        public override bool HasColumn()
        {
            throw new NotImplementedException();
        }

        public override bool HasForeignKey(string foreignKeyName)
        {
            throw new NotImplementedException();
        }

        public override bool HasIndex()
        {
            throw new NotImplementedException();
        }
    }
}
