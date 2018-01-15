using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.Domain
{
    public interface IBaseEntity
    {

    }
   public abstract class BaseEntity<TKey>: IBaseEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public virtual TKey Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreatedAt { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        public virtual DateTime UpdatedAt { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Description("排序号")]
        public virtual long SequenceNo { get; set; }
        public BaseEntity()
        {
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }
    }

    public abstract class BaseEntity: BaseEntity<Guid>
    {

    }
}
