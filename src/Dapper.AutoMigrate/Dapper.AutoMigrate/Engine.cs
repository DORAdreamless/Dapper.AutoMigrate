using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.AutoMigrate
{
    public class Engine
    {
        protected static string ConnectionString;
        private static string ProviderInvariantName;

        private static ConcurrentDictionary<Type, object> paramCache = new ConcurrentDictionary<Type, object>();

        public static IDbConnection GetDbConnection()
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(ProviderInvariantName);
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            return dbConnection;
        }

        public static void RegisterDataBase(string providerInvariantName, string connectionString)
        {
            Engine.ProviderInvariantName = providerInvariantName;
            Engine.ConnectionString = connectionString;
        }

        public static void RegisterModel(Type type)
        {
            if (paramCache.ContainsKey(type))
            {
                throw new Exception("类型已经存在！");
            }
            paramCache.TryAdd(type, null);
        }

        public static void RunSync()
        {

        }
    }
}
