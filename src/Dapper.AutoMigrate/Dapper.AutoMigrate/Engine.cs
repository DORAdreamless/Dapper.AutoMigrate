﻿using Dapper.AutoMigrate.Fluent;
using Dapper.AutoMigrate.Mysql;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Dapper.AutoMigrate
{
    public class Engine
    {
        protected static string ConnectionString;
        private static string ProviderInvariantName;

        private static EntityMapper EntityMapper { get; }


        private static ConcurrentDictionary<Type, EntityMapper> paramCache = new ConcurrentDictionary<Type, EntityMapper>();

        public static IDbConnection GetDbConnection()
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(ProviderInvariantName);
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            return dbConnection;
        }

        public static IDbCommand GetDbCommand(IDbConnection connection)
        {
            return connection.CreateCommand();
        }

        public static IDataReader GetReader(IDbCommand command)
        {
            return command.ExecuteReader();
        }

        public static void RegisterDataBase(string providerInvariantName, string connectionString)
        {
            Engine.ProviderInvariantName = providerInvariantName;
            Engine.ConnectionString = connectionString;
        }

        public static void RegisterModel(Type entityMapperType)
        {
            if (paramCache.ContainsKey(entityMapperType))
            {
                throw new Exception("类型已经存在！");
            }
           

            if (!entityMapperType.IsDefined(typeof(TableAttribute)))
            {
                return;
            }
            EntityMapper entityMapper = Engine.GetEntityMapper(entityMapperType);

            PropertyInfo[] properties = entityMapperType.GetProperties(BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                if (property.IsDefined(typeof(ColumnAttribute)))
                {
                    PropertyMapper propertyMapper = Engine.GetPropertyMapper(entityMapper, property);
                    entityMapper.PropertyMappers.Add(propertyMapper);
                }

            }
            paramCache.TryAdd(entityMapperType, entityMapper);
        }

    
        public static void RunSync(bool force=false)
        {
            string sql = string.Empty;
            foreach (var entityMapper in paramCache.Values)
            {
                sql=entityMapper.GetCreateTableDDL();
                if (string.IsNullOrWhiteSpace(sql))
                    continue;
                using (var connection = Engine.GetDbConnection())
                {
                    if (force)
                    {
                        connection.Execute("DROP TABLE IF EXISTS `" + entityMapper.TableName + "`;");
                    }
                    connection.Execute(sql);
                }
            }
        }


        public static EntityMapper GetEntityMapper(Type entityMapperType)
        {
            return new MySqlEntityMapper(entityMapperType);
        }

        public static PropertyMapper GetPropertyMapper(EntityMapper entityMapper, PropertyInfo property)
        {
            return new MySqlPropertyMapper(entityMapper, property);
        }
    }
}
