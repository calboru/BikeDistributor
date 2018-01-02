using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BikeDistributor.Data.Interfaces.Common;
using BikeDistributor.Shared.Interfaces;

namespace BikeDistributor.Interfaces.CommonServices
{
    public interface IDataRepositoryService
    {
       
        IRepository Repository { get; set; }
        IEntityMappingService EntityMapperService { get; set; }

        TModel GetOne<TModel, TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class, IEntity
            where TModel : class;

        IEnumerable<TModel> GetAll<TModel, TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
            where TModel : class;

        Task<IEnumerable<TModel>> GetAllAsync<TModel, TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
            where TModel : class;

        IEnumerable<TModel> Get<TModel, TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
            where TModel : class;

        Task<IEnumerable<TModel>> GetAsync<TModel, TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
            where TModel : class;
 
        Task<TModel> GetOneAsync<TModel, TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class, IEntity
            where TModel : class;

        TModel GetFirst<TModel, TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class, IEntity
            where TModel : class;

        Task<TModel> GetFirstAsync<TModel, TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class, IEntity
            where TModel : class;

        TModel GetById<TModel, TEntity>(object id)
            where TEntity : class, IEntity
            where TModel : class;

        Task<TModel> GetByIdAsync<TModel, TEntity>(object id)
            where TEntity : class, IEntity
            where TModel : class;

        int GetCount<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
            where TModel : class;

        Task<int> GetCountAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
            where TModel : class;

        bool GetExists<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
            where TModel : class;

        Task<bool> GetExistsAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
            where TModel : class;

        #region "CRUD"

        void Create<TModel, TEntity>(TModel model, string createdBy = null)
            where TEntity : class, IEntity
            where TModel : class;
            

        void Update<TModel, TEntity>(TModel model, string modifiedBy = null)
            where TEntity : class, IEntity
            where TModel : class;

        void Delete<TEntity>(object id) where TEntity : class, IEntity;

        void Delete<TModel, TEntity>(TModel model)
            where TEntity : class, IEntity
            where TModel : class;

        void Save();

        Task SaveAsync();

        #endregion
 
    }
}

