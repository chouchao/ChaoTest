using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Res.Core
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Provides the main entry point to a LINQ query.
        /// </summary>
        IQueryable<TEntity> LinqQuery { get; }

        /// <summary>
        /// Return the persistent instance of the given entity type with the given identifier,
        /// or null if not found.  Obtains the specified lock mode if the instance exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(long id);

        /// <summary>
        /// Persist the given transient instance with the given identifier.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        long Save(TEntity entity);

        /// <summary>
        /// Update the given persistent instance.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Save or update the given persistent instance, according to its id (matching
        /// the configured "unsaved-value"?).
        /// </summary>
        /// <param name="entity"></param>
        void SaveOrUpdate(TEntity entity);

        /// <summary>
        /// Delete the given persistent instance.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete all objects returned by the query.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        int Delete(string queryString);

        /// <summary>
        /// Remove all objects from the Session cache, and cancel all pending saves,
        /// updates and deletes.
        /// </summary>
        void Clear();

        /// <summary>
        /// Re-read the state of the given persistent instance.
        /// </summary>
        /// <param name="entity"></param>
        void Refresh(TEntity entity);

        /// <summary>
        /// Flush all pending saves, updates and deletes to the database.
        /// </summary>
        void Flush();

        /// <summary>
        /// Remove the given object from the Session cache.
        /// </summary>
        /// <param name="entity"></param>
        void Evict(TEntity entity);
    }
}
