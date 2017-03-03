﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.Model.Common;

namespace Ebuy.Service.Common
{
    public interface ISportService
    {
        Task<List<ISport>> GetAllAsync(string search, int page, string sortBy);
        Task<ISport> GetAsync(int? id);
        IEnumerable<ISport> Find(Expression<Func<ISport, bool>> predicate);
        Task<int> AddAsync(ISport entity);
        Task<int> RemoveAsync(ISport entity);
        Task<int> UpdateAsync(ISport entity);
    }
}
