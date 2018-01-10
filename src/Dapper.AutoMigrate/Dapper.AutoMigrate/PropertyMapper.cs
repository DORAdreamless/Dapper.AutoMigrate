using Dapper.AutoMigrate.Fluent;
using Dapper.AutoMigrate.Utility;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Dapper.AutoMigrate
{
    public abstract class PropertyMapper
    {
        public EntityMapper EntityMapper { get; }

        public PropertyMapper(EntityMapper entityMapper, PropertyInfo property)
        {
            this.PropertyType = property.PropertyType;
            this.EntityMapper = entityMapper;

            ColumnAttribute columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            this.ColumnName = columnAttribute.ColumnName;
            if (string.IsNullOrWhiteSpace(this.ColumnName))
            {
                this.ColumnName = StringUtils.GetSnackName(property.Name);
            }
            this.DbType = columnAttribute.Type;
            if (string.IsNullOrWhiteSpace(this.DbType))
            {
                this.DbType = this.GetDataType();
                //自动映射
            }
            this.Unique = columnAttribute.Unique;
            this.Index = columnAttribute.Index;
            this.Size = columnAttribute.Size;
            this.ColumnDescription = property.Name;
            if (property.IsDefined(typeof(DescriptionAttribute)))
            {
                this.ColumnDescription = property.GetCustomAttribute<DescriptionAttribute>().Description;
            }
            if (property.IsDefined(typeof(PrimaryKeyAttribute)))
            {
                this.ParmaryKey = true;
                this.Auto =   property.GetCustomAttribute<PrimaryKeyAttribute>().Auto;
            }

            
        }

        public string ColumnName { get; set; }

        public string ColumnDescription { get; set; }

        public string DbType { get; set; }

        public bool Unique { get; set; }

        public bool Index { get; set; }

        public int Size { get; set; }

        public string Default { get; set; }
        public bool NotNull { get; set; }

        public Type PropertyType { get; set; }
        public bool ParmaryKey { get;  set; }
        public bool Auto { get;  set; }

        public abstract bool HasColumn();

        public abstract bool HasIndex();

        public abstract bool HasForeignKey(string foreignKeyName);

        public abstract string GetCreateColumnSQL();

        public abstract string GetAlterColumnSQL();

        public abstract string GetDropColumnSQL();

        public abstract string GetDataType();
    }
}
