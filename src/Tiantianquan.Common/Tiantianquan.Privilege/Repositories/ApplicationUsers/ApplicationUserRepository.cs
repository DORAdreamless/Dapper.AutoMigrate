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
    /// SYS_ApplicationUser
    /// </summary>
    public class ApplicationUserRepository : NhibernateRepository<ApplicationUser,String>, IApplicationUserRepository
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
        /// UserName
        /// </summary>
        public const string __UserName__ = "UserName";
        /// <summary>
        /// PasswordHash
        /// </summary>
        public const string __PasswordHash__ = "PasswordHash";
        /// <summary>
        /// PasswordSalt
        /// </summary>
        public const string __PasswordSalt__ = "PasswordSalt";
        /// <summary>
        /// NickName
        /// </summary>
        public const string __NickName__ = "NickName";
        /// <summary>
        /// FirstName
        /// </summary>
        public const string __FirstName__ = "FirstName";
        /// <summary>
        /// LastName
        /// </summary>
        public const string __LastName__ = "LastName";
        /// <summary>
        /// Sex
        /// </summary>
        public const string __Sex__ = "Sex";
        /// <summary>
        /// Birthday
        /// </summary>
        public const string __Birthday__ = "Birthday";
        /// <summary>
        /// Age
        /// </summary>
        public const string __Age__ = "Age";
        /// <summary>
        /// Phone
        /// </summary>
        public const string __Phone__ = "Phone";
        /// <summary>
        /// Email
        /// </summary>
        public const string __Email__ = "Email";
        /// <summary>
        /// HeadImageUrl
        /// </summary>
        public const string __HeadImageUrl__ = "HeadImageUrl";
        /// <summary>
        /// LastLoginTime
        /// </summary>
        public const string __LastLoginTime__ = "LastLoginTime";
        /// <summary>
        /// LastLoginIP
        /// </summary>
        public const string __LastLoginIP__ = "LastLoginIP";
        /// <summary>
        /// Locked
        /// </summary>
        public const string __Locked__ = "Locked";
        /// <summary>
        /// LockedTime
        /// </summary>
        public const string __LockedTime__ = "LockedTime";
        /// <summary>
        /// Logined
        /// </summary>
        public const string __Logined__ = "Logined";
        #endregion
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams">分页查询条件</param>
        /// <returns></returns>
        public List<ApplicationUser> GetApplicationUserByPage(ApplicationUserSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<ApplicationUser>();
            if (!string.IsNullOrWhiteSpace(searchParams.Keywords))
            {
               // criteria.Add(Restrictions.Like(__CategoryName__, "%" + searchParams.Keywords + "%"));
            }
            
            //criteria.AddOrder(Order.Asc(__CategoryName__));
            criteria.SetFirstResult(searchParams.GetFirstResult());
            criteria.SetMaxResults(searchParams.GetMaxResults());

            var items=criteria.List<ApplicationUser>().ToList();

            return items;
        }
        
        /// <summary>
        /// 查总记录数
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public int GetApplicationUserRecordCount(ApplicationUserSearchParams searchParams)
        {
            var criteria = this.Session.CreateCriteria<ApplicationUser>();
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