using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.Runtime
{
   public  class Constants
    {
        /// <summary>
        /// 首页头部导航链接
        /// </summary>
        public const string Header_Cache_Key = "Header_Cache_Key";
        /// <summary>
        /// 首页推荐
        /// </summary>
        public const string Reference_Cache_Key = "Reference_Cache_Key";
        /// <summary>
        /// 关于我们
        /// </summary>
        public static Guid Singlepage_Page_About = Guid.Parse(ConfigurationManager.AppSettings["Singlepage_Page_About"]);
    }
}
