﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        T Get(Expression<Func<T, bool>> filter);

        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
