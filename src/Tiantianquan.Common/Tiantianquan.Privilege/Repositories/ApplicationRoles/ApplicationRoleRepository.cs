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
    /// SYS_ApplicationRole
    /// </summary>
    public class ApplicationRoleRepository : NhibernateRepository<ApplicationRole,String>, IApplicationRoleRepository
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
        /// Name
        /// </summary>
        public const string __Name__ = "Name";
        /// <summary>
        /// Description
        /// </summary>
        public const string __Description__ = "Description";
        #endregion
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams">分页查询条件</param>
        /// <returns></returns>
        public List<ApplicationRole> GetApplicationRoleByPage(ApplicationRoleSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<ApplicationRole>();
            if (!string.IsNullOrWhiteSpace(searchParams.Keywords))
            {
               // criteria.Add(Restrictions.Like(__CategoryName__, "%" + searchParams.Keywords + "%"));
            }
            
            //criteria.AddOrder(Order.Asc(__CategoryName__));
            criteria.SetFirstResult(searchParams.GetFirstResult());
            criteria.SetMaxResults(searchParams.GetMaxResults());

            var items=criteria.List<ApplicationRole>().ToList();

            return items;
        }
        
        /// <summary>
        /// 查总记录数
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public int GetApplicationRoleRecordCount(ApplicationRoleSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<ApplicationRole>();
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