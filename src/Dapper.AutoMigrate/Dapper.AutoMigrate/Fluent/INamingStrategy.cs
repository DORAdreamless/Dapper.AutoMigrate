using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.AutoMigrate.Fluent
{
   public interface INamingStrategy
    {
        /// <summary>
        /// Return a table name for an entity class
        /// </summary>
        /// <param name="className">the fully-qualified class name</param>
        /// <returns>a table name</returns>
        string ClassToTableName(string className);

        /// <summary>
        /// Return a column name for a property path expression 
        /// </summary>
        /// <param name="propertyName">a property path</param>
        /// <returns>a column name</returns>
        string PropertyToColumnName(string propertyName);

    }
}
