using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper.AutoMigrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.AutoMigrate.Tests.Samples;

namespace Dapper.AutoMigrate.Tests
{
    [TestClass()]
    public class EngineTests
    {
        [TestMethod()]
        public void RunSyncTest()
        {
            Engine.RegisterDataBase("MySql.Data.MySqlClient", "server=localhost;uid=root;pwd=123456;database=cloud;");

            Engine.RegisterModel(typeof(User));
            Engine.RunSync(true);
        }
    }
}