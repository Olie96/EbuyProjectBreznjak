﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;

namespace Ebuy.Repository.Common
{
    public interface ICarRepository
    {
        Task<List<ICars>> GetAllAsync(string search, int page, string sortBy);
        Task<ICars> GetAsync(int? id);
        IEnumerable<ICars> Find(Expression<Func<ICars, bool>> predicate);
        Task<int> AddAsync(ICars entity);
        Task<int> RemoveAsync(ICars entity);
        Task<int> UpdateAsync(ICars entity);
    }
}
