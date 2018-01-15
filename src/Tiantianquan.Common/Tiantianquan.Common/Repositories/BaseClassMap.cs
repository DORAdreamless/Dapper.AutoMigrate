using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Common.Repositories
{
    public abstract class BaseClassMap<TEntity, TKey> : ClassMap<TEntity> where TEntity : BaseEntity<TKey>
    {
        public BaseClassMap()
        {
            this.Id(item => item.Id).GeneratedBy.Assigned();
            this.Map(item => item.CreatedAt).Index("IDX_"+typeof(TEntity).Name+"_CreatedAt");
            this.Map(item => item.UpdatedAt);
            this.Map(item => item.SequenceNo);
        }
    }

    public abstract class BaseClassMap<TEntity> : BaseClassMap<TEntity,Guid> where TEntity : BaseEntity<Guid>
    {
      
    }
}
