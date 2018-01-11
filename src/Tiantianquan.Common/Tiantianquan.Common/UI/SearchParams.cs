using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.UI
{
   public class SearchParams
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// 模糊搜索
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public string Order { get; set; }

        public SearchParams()
        {
            this.Page = 1;
            this.Rows = 10;
            this.Keywords = string.Empty;
        }
        public int GetFirstResult()
        {
            int start= (this.Page - 1) * this.GetMaxResults();
            if (start < 0)
            {
                return start=0;
            }
            return start;
        }

        public int GetMaxResults()
        {
            if (this.Rows <= 0)
            {
                return 10;
            }

            return this.Rows;
        }

        public const string Asc = "asc";

        public const string Desc = "desc";

        public bool IsClientSort()
        {
            if (string.IsNullOrWhiteSpace(this.Order) || string.IsNullOrWhiteSpace(this.Sort))
            {
                return false;
            }
            return true;
        }
        public ICriteria CreateOrderCriteria(ICriteria criteria)
        {
            if (!this.IsClientSort())
            {
                return criteria;
            }
            if (this.Order.ToLower() == Asc)
            {
                 criteria.AddOrder(NHibernate.Criterion.Order.Asc(this.Sort));
            }else if (this.Order.ToLower() == Desc)
            {
                 criteria.AddOrder(NHibernate.Criterion.Order.Desc(this.Sort));
            }
            return criteria;
        }
    }
}
