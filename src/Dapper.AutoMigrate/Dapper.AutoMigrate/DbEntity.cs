using Dapper.AutoMigrate;
using Dapper.AutoMigrate.Fluent;
using System;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Reflection;

namespace Dapper.AutoMigrate
{
    //public class Engine
    //{
    //    private static ConcurrentDictionary<Type, object> paramCache = new ConcurrentDictionary<Type, object>();

    //    private static EntityMapper EntityMapper { get; }

    //    public static void RunSync()
    //    {
    //        Type entityMapperType = typeof(User);

    //        if (!entityMapperType.IsDefined(typeof(TableAttribute)))
    //        {
                
    //        }
    //        EntityMapper entityMapper = Engine.GetEntityMapper(entityMapperType);
           
    //        PropertyInfo[] properties=entityMapperType.GetProperties(BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public);

    //        foreach (var property in properties)
    //        {
    //            if (property.IsDefined(typeof(ColumnAttribute)))
    //            {
    //                PropertyMapper propertyMapper = Engine.GetPropertyMapper(entityMapper, property);
    //                entityMapper.Fields.Add(propertyMapper);
    //            }
           
    //        }
    //        entityMapper.GetCreateTableDDL();
    //    }


    //    public static EntityMapper GetEntityMapper(Type entityMapperType)
    //    {
    //        return new MysqlEntityMapper(entityMapperType);
    //    }

    //    public static PropertyMapper GetPropertyMapper(EntityMapper entityMapper,PropertyInfo property)
    //    {
    //        return new MySqlPropertyMapper(entityMapper, property);
    //    }
    //}

 
    public class DbEntity:IDbEntity
    {
        [PrimaryKey]
        [Column()]
        public Guid Id { get; set; }
        [Column()]
        public DateTime CreatedAt { get; set; }
        [Column()]
        public DateTime UpdatedAt { get; set; }
        [Column()]
        public DateTime? DeletedAt { get; set; }
    }

   

}
