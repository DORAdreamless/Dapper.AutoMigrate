using System;
using System.Linq;
using System.Reflection;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using NHibernate.Cfg;

namespace NHibernate.Cfg
{
   

    public static class PropertyPartExtension
    {
        public static PropertyPart Index(this PropertyPart propertyPart)
        {
            FieldInfo parentField = typeof(PropertyPart).GetRuntimeFields().FirstOrDefault(item=>item.Name== "parentType");
            FieldInfo memberField = typeof(PropertyPart).GetRuntimeFields().FirstOrDefault(item => item.Name == "member");

            System.Type entityType = parentField.GetValue(propertyPart) as System.Type;
            Member memberType = memberField.GetValue(propertyPart) as Member;

            string idx_name = string.Format("idx_{0}_{1}",
                LowerImprovedNamingStrategy.Instance.ClassToTableName(entityType.Name),
                LowerImprovedNamingStrategy.Instance.PropertyToColumnName(memberType.Name)
                );
            propertyPart.Index(idx_name);
            return propertyPart;
        }

      
    }
}
