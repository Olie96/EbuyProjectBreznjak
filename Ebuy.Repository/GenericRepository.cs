﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;

namespace Ebuy.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public GenericRepository(IMyDbContext context)
        {
            Context = context;
        }
        private readonly IMyDbContext Context;

        public async Task<int> AddAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return await Context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        //public async Task<IEnumerable<TEntity>> GetAll()
        //{
        //   return await Context.Set<TEntity>().ToListAsync();
        //}

        public async Task<int> RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }
    }
}
