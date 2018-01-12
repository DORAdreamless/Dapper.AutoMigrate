using NHibernate.Criterion;
using Tiantianquan.Common.UI;
using System.Collections.Generic;
using System.Linq;
using Tiantianquan.Common.Repositories;
using Tiantianquan.Common.Enums;
using System;
using Tiantianquan.Privilege.Domain;


namespace Tiantianquan.PrivilegeRepositories
{
    /// <summary>
    /// SYS_Permission
    /// </summary>
    public class PermissionRepository : NhibernateRepository<Permission,String>, IPermissionRepository
    {
        #region 属性名常量
        /// <summary>
        /// Id
        /// </summary>
        public const string __Id__ = "Id";
        /// <summary>
        /// CreatedAt
        /// </summary>
        public const string __CreatedAt__ = "CreatedAt";
        /// <summary>
        /// UpdatedAt
        /// </summary>
        public const string __UpdatedAt__ = "UpdatedAt";
        /// <summary>
        /// ApplicationId
        /// </summary>
        public const string __ApplicationId__ = "ApplicationId";
        /// <summary>
        /// ApplicationRoleId
        /// </summary>
        public const string __ApplicationRoleId__ = "ApplicationRoleId";
        /// <summary>
        /// ApplicationUserId
        /// </summary>
        public const string __ApplicationUserId__ = "ApplicationUserId";
        /// <summary>
        /// NavigationMenuId
        /// </summary>
        public const string __NavigationMenuId__ = "NavigationMenuId";
        /// <summary>
        /// Granted
        /// </summary>
        public const string __Granted__ = "Granted";
        /// <summary>
        /// CreatedUserId
        /// </summary>
        public const string __CreatedUserId__ = "CreatedUserId";
        #endregion
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams">分页查询条件</param>
        /// <returns></returns>
        public List<Permission> GetPermissionByPage(PermissionSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<Permission>();
            if (!string.IsNullOrWhiteSpace(searchParams.Keywords))
            {
               // criteria.Add(Restrictions.Like(__CategoryName__, "%" + searchParams.Keywords + "%"));
            }
            
            //criteria.AddOrder(Order.Asc(__CategoryName__));
            criteria.SetFirstResult(searchParams.GetFirstResult());
            criteria.SetMaxResults(searchParams.GetMaxResults());

            var items=criteria.List<Permission>().ToList();

            return items;
        }
        
        /// <summary>
        /// 查总记录数
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public int GetPermissionRecordCount(PermissionSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<Permission>();
            if (!string.IsNullOrWhiteSpace(searchParams.Keywords))
            {
               // criteria.Add(Restrictions.Like(__CategoryName__, "%" + searchParams.Keywords + "%"));
            }
            criteria.SetProjection(Projections.RowCount());
            int total = (int)criteria.UniqueResult();

            return total;
        }
    }
}