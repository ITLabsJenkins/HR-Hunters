﻿using System;
using System.Collections.Generic;
using System.Text;
using HRHunters.Common.Entities;
using HRHunters.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRHunters.Data
{
    public class EFRepository<TContext>: EFReadOnlyRepository<TContext>, IRepository
        where TContext: DbContext
    {
        public EFRepository(TContext context) : base(context) { }

        public virtual void Create<TEntity>(TEntity entity, string createdBy = null)
        where TEntity : Entity
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = createdBy;
            context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : Entity
        {
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : Entity
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : Entity
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
               //ToDO
            }
        }

      
    }
}