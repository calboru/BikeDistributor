using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BikeDistributor.Data.Interfaces.Common;
using BikeDistributor.Data.Common;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Services.Common;
using BikeDistributor.Shared.Interfaces;
using Unity.Attributes;

namespace BikeDistributor.Services.Data
{
    public class DataRepositoryService : BaseService, IDataRepositoryService
       
    {
        [Dependency]
        public virtual IRepository Repository { get; set; }

        [Dependency]
        public virtual IEntityMappingService EntityMapperService { get; set; }

        public virtual TModel GetOne<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = Repository.GetOne(filter, includeProperties);
            var result = EntityMapperService.Map<TEntity, TModel>(dbResult);
            return result;
        }

        public virtual IEnumerable<TModel> GetAll<TModel, TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null,
            int? take = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = Repository.GetAll(orderBy, includeProperties, skip, take);
            var result = EntityMapperService.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(dbResult);
            return result;
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync<TModel, TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null,
            int? take = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = await Repository.GetAllAsync<TEntity>(orderBy, includeProperties, skip, take);
            var result = EntityMapperService.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(dbResult);
            return result;
        }

        public virtual IEnumerable<TModel> Get<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = Repository.Get<TEntity>(filter, orderBy, includeProperties, skip, take);
            var result = EntityMapperService.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(dbResult);
            return result;
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = await Repository.GetAsync<TEntity>(filter, orderBy, includeProperties, skip, take);
            var result = EntityMapperService.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(dbResult);
            return result;
        }

        public virtual async Task<TModel> GetOneAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = await Repository.GetOneAsync(filter, includeProperties);
            var result = EntityMapperService.Map<TEntity, TModel>(dbResult);
            return result;
        }

        public virtual TModel GetFirst<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = Repository.GetFirst(filter, orderBy, includeProperties);
            var result = EntityMapperService.Map<TEntity, TModel>(dbResult);
            return result;
        }

        public virtual async Task<TModel> GetFirstAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = await Repository.GetFirstAsync(filter, orderBy, includeProperties);
            var result = EntityMapperService.Map<TEntity, TModel>(dbResult);
            return result;
        }

        public virtual TModel GetById<TModel, TEntity>(object id) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = Repository.GetById<TEntity>(id);
            var result = EntityMapperService.Map<TEntity, TModel>(dbResult);
            return result;
        }

        public virtual async Task<TModel> GetByIdAsync<TModel, TEntity>(object id) where TModel : class where TEntity : class, IEntity
        {
            var dbResult = await Repository.GetByIdAsync<TEntity>(id);
            var result = EntityMapperService.Map<TEntity, TModel>(dbResult);
            return result;
        }

        public virtual int GetCount<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null) where TModel : class where TEntity : class, IEntity
        {
            return Repository.GetCount(filter);
        }

        public virtual async Task<int> GetCountAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null) where TModel : class where TEntity : class, IEntity
        {
            return await Repository.GetCountAsync(filter);
        }

        public virtual bool GetExists<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null) where TModel : class where TEntity : class, IEntity
        {
            return Repository.GetExists(filter);
        }

        public virtual async Task<bool> GetExistsAsync<TModel, TEntity>(Expression<Func<TEntity, bool>> filter = null) where TModel : class where TEntity : class, IEntity
        {
            return await Repository.GetExistsAsync(filter);
        }

        public virtual void Create<TModel, TEntity>(TModel model, string createdBy = null) where TModel : class where TEntity : class, IEntity
        {
            try
            {
                var entity = EntityMapperService.Map<TModel, TEntity>(model);
                Repository.Create(entity, createdBy);
                LogService.Info(entity);
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }
            
        }

        public virtual void Update<TModel, TEntity>(TModel model, string modifiedBy = null) where TModel : class where TEntity : class, IEntity
        {
            var entity = EntityMapperService.Map<TModel, TEntity>(model);
            Repository.Update(entity, modifiedBy);
        }

        public virtual void Delete<TEntity>(object id) where TEntity : class, IEntity
        {
            Repository.Delete<TEntity>(id);
        }

    
        public virtual void Delete<TModel, TEntity>(TModel model) where TModel : class where TEntity : class, IEntity
        {
            var entity = EntityMapperService.Map<TModel, TEntity>(model);
            Repository.Delete(entity);
        }

        public virtual void Save()
        {
           Repository.Save();
        }

        public virtual Task SaveAsync()
        {
            return  Repository.SaveAsync();
        }
        public virtual void ExecuteSql(string sql)
        {
            Repository.ExecuteSql(sql);
        }
    }
}
