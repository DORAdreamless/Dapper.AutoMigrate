using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Common.Repositories
{
    public interface IRepository
    {

    }
   public interface IRepository<TEntity,TKey>: IRepository where TEntity:BaseEntity<TKey>
    {
        TKey Save(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        void BatchDelete(IEnumerable<TKey> ids);

        List<TEntity> GetByIds(IEnumerable<TKey> ids);

        TEntity GetById(TKey id);

        IQueryable<TEntity> GetAll();


    }

    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : BaseEntity<Guid>
    {

    }
}
