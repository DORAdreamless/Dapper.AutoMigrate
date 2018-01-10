using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Cfg
{
    /// <summary>
    /// Summary description for ImprovedNamingStrategy.
    /// </summary>
    public class LowerImprovedNamingStrategy : INamingStrategy
    {
        /// <summary>
        /// The singleton instance
        /// </summary>
        public static readonly INamingStrategy Instance = new LowerImprovedNamingStrategy();

        private LowerImprovedNamingStrategy()
        {
        }

        #region INamingStrategy Members

        /// <summary>
        /// Return the unqualified class name, mixed case converted to underscores
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public string ClassToTableName(string className)
        {
            return AddUnderscores(StringHelper.Unqualify(className));
        }

        /// <summary>
        /// Return the full property path with underscore separators, mixed case converted to underscores
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string PropertyToColumnName(string propertyName)
        {
            return AddUnderscores(StringHelper.Unqualify(propertyName));
        }

        /// <summary>
        /// Convert mixed case to underscores
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string TableName(string tableName)
        {
            return AddUnderscores(tableName);
        }

        /// <summary>
        /// Convert mixed case to underscores
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string ColumnName(string columnName)
        {
            return AddUnderscores(columnName);
        }

        /// <summary>
        /// Return the full property path prefixed by the unqualified class name, with underscore separators, mixed case converted to underscores
        /// </summary>
        /// <param name="className"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string PropertyToTableName(string className, string propertyName)
        {
            return AddUnderscores(StringHelper.Unqualify(propertyName));
        }

        public string LogicalColumnName(string columnName, string propertyName)
        {
            return StringHelper.IsNotEmpty(columnName) ? columnName : StringHelper.Unqualify(propertyName);
        }

        #endregion

        private string AddUnderscores(string name)
        {
            char[] chars = name.Replace('.', '_').ToCharArray();
            StringBuilder buf = new StringBuilder(chars.Length);


            int counter = 0;
            foreach (char c in chars)
            {
                if (c != '_' && char.IsUpper(c) && counter>0)
                {
                    buf.Append('_');
                }
                buf.Append(char.ToLowerInvariant(c));

                if (c != '`')
                {
                    counter++;
                }
                
            }

            return buf.ToString();
        }
    }
}
