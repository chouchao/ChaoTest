using System.Collections.Generic;
using System.Linq;
using Spring.Data.NHibernate.Generic.Support;
using NHibernate;
using NHibernate.Linq;


namespace Res.Core
{
    public class Repository<TEntity> : HibernateDaoSupport, IRepository<TEntity> where TEntity : IEntity
    {
        public virtual IQueryable<TEntity> LinqQuery
        {
            get { return new NhQueryable<TEntity>(Session.GetSessionImplementation()); }
        }

        public virtual TEntity Get(long id)
        {
            return HibernateTemplate.Get<TEntity>(id);
        }

        public virtual long Save(TEntity entity)
        {
            long r;
            object o = HibernateTemplate.Save(entity);
            long.TryParse(o.ToString(), out r);
            return r;
        }

        public virtual void Update(TEntity entity)
        {
            HibernateTemplate.Update(entity);
        }

        public virtual void SaveOrUpdate(TEntity entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public virtual int Delete(string queryString)
        {
            return HibernateTemplate.Delete(queryString);
        }

        public void Clear()
        {
            HibernateTemplate.Clear();
        }

        public void Refresh(TEntity entity)
        {
            HibernateTemplate.Refresh(entity);
        }

        public virtual void Flush()
        {
            HibernateTemplate.Flush();
        }

        public virtual void Evict(TEntity entity)
        {
            HibernateTemplate.Evict(entity);
        }
    }
}
