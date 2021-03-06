﻿using HRHunters.Common.Entities;
using HRHunters.Common.Enums;
using HRHunters.Common.Interfaces;
using HRHunters.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HRHunters.Domain.Managers
{
    public class BaseManager : IBaseManager
    { 
        private readonly IRepository _repo;
        public BaseManager(IRepository repo)
        {
            _repo = repo;
        }
        public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : Entity
        {
            _repo.Create(entity, createdBy);
            Save();
        }

        public void Delete<TEntity>(object id) where TEntity : Entity
        {
            _repo.Delete<TEntity>(id);
            Save();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            _repo.Delete(entity);
            Save();
        }

        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : Entity
        {
            return _repo.Get(filter, includeProperties);
        }

        public IQueryable<TEntity> GetAll<TEntity>(string includeProperities) where TEntity : Entity
        {
            return _repo.GetAll<TEntity>(includeProperties: null);
        }

        public TEntity GetById<TEntity>(object id) where TEntity : Entity
        {
            return _repo.GetById<TEntity>(id);
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : Entity
        {
            return _repo.GetCount(filter);
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : Entity
        {
            return _repo.GetExists(filter);
        }

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : Entity
        {
            return _repo.GetOne(filter, includeProperties);
        }

        public void Save()
        {
            _repo.Save();
        }

        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : Entity
        {
            _repo.Update(entity, modifiedBy);
            Save();
        }
    }
}
