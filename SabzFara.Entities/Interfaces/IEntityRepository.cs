﻿using SabzFara.Entities.Context;
using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SabzFara.Entities.Interfaces
{
    public interface IEntityRepository<TContext,TEntity> where TContext:DbContext,new()
        where TEntity:class,IEntity,new()
    {
        void AddOrUpdate(TContext context, TEntity entity);
        void Delete(TContext context, Expression<Func<TEntity, bool>> filter);
        void Save(TContext context);
    }
}