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
    /// SYS_NavigationMenu
    /// </summary>
    public class NavigationMenuRepository : NhibernateRepository<NavigationMenu,String>, INavigationMenuRepository
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
        /// ParentId
        /// </summary>
        public const string __ParentId__ = "ParentId";
        /// <summary>
        /// Name
        /// </summary>
        public const string __Name__ = "Name";
        /// <summary>
        /// DisplayName
        /// </summary>
        public const string __DisplayName__ = "DisplayName";
        /// <summary>
        /// Style
        /// </summary>
        public const string __Style__ = "Style";
        /// <summary>
        /// LinkAddress
        /// </summary>
        public const string __LinkAddress__ = "LinkAddress";
        /// <summary>
        /// ResourceType
        /// </summary>
        public const string __ResourceType__ = "ResourceType";
        /// <summary>
        /// Attributes
        /// </summary>
        public const string __Attributes__ = "Attributes";
        #endregion
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams">分页查询条件</param>
        /// <returns></returns>
        public List<NavigationMenu> GetNavigationMenuByPage(NavigationMenuSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<NavigationMenu>();
            if (!string.IsNullOrWhiteSpace(searchParams.Keywords))
            {
               // criteria.Add(Restrictions.Like(__CategoryName__, "%" + searchParams.Keywords + "%"));
            }
            
            //criteria.AddOrder(Order.Asc(__CategoryName__));
            criteria.SetFirstResult(searchParams.GetFirstResult());
            criteria.SetMaxResults(searchParams.GetMaxResults());

            var items=criteria.List<NavigationMenu>().ToList();

            return items;
        }
        
        /// <summary>
        /// 查总记录数
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public int GetNavigationMenuRecordCount(NavigationMenuSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<NavigationMenu>();
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