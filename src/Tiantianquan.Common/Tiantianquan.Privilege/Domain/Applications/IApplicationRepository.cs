using System.Collections.Generic;
using Tiantianquan.Common.Enums;
using Tiantianquan.Common.Repositories;
using Tiantianquan.Common.UI;
using System;

namespace Tiantianquan.Privilege.Domain
{
    /// <summary>
    /// 应用
    /// </summary>
    public interface IApplicationRepository : IRepository<Application,String>
    {
     /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams">分页查询条件</param>
        /// <returns></returns>
        List<Application> GetApplicationByPage(ApplicationSearchParams searchParams);
        
         /// <summary>
        /// 查总记录数
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        int GetApplicationRecordCount(ApplicationSearchParams searchParams);
    }
}
