using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Domain;

namespace Tiantianquan.Common.Repositories
{
    public abstract class NhibernateRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public ISession Session
        {
            get
            {
                return NhSessionFactory.GetCurrentSession();
            }
        }
        public void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        public void Delete(TKey id)
        {
            TEntity entity = Session.Load<TEntity>(id);
            Session.Delete(entity);
        }

        public void BatchDelete(IEnumerable<TKey> ids)
        {
            string entityName = typeof(TEntity).Name;
            string hql = "delete from " + entityName + " as t where t.Id in (:ids)";
            Session.CreateQuery(hql).SetParameterList("ids", ids).ExecuteUpdate();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public TEntity GetById(TKey id)
        {
            return Session.Get<TEntity>(id);
        }

        public List<TEntity> GetByIds(IEnumerable<TKey> ids)
        {
            ICriteria criteria = Session.CreateCriteria<TEntity>();
            criteria.Add(Restrictions.In("Id", ids.ToArray()));
            return criteria.List<TEntity>().ToList();
        }

        public TKey Save(TEntity entity)
        {
            return (TKey)Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            // Session.Evict(entity);
            //  Session.Merge(entity);
            Session.Update(entity);
        }
    }

    public abstract class NhibernateRepository<TEntity> : NhibernateRepository<TEntity, Guid> where TEntity : BaseEntity<Guid>
    {

    }

}
