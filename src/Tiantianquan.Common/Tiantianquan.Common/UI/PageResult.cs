using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.UI
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T>
    {
        [JsonProperty("total")]
        public int Total { get; }
        [JsonProperty("rows")]
        public List<T> Rows { get; }

        public PageResult(int total, List<T> items)
        {
            this.Rows = items;
            this.Total = total;
        }

        public PageResult(int total, IEnumerable<T> items)
        {
            this.Rows = items.ToList();
            this.Total = total;
        }
    }
}
