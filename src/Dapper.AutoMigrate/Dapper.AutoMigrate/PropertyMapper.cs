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
            this.Type = columnAttribute.Type;
            if (string.IsNullOrWhiteSpace(this.Type))
            {
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
        }

        public string ColumnName { get; set; }

        public string ColumnDescription { get; set; }

        public string Type { get; set; }

        public bool Unique { get; set; }

        public bool Index { get; set; }

        public int Size { get; set; }

        public string Default { get; set; }
        public bool NotNull { get; set; }

        public Type PropertyType { get; set; }
        public bool ParmaryKey { get; internal set; }

        public abstract string GetCreateColumnSQL();

        public abstract string GetAlterColumnSQL();

        public abstract string GetDropColumnSQL();
    }
}
