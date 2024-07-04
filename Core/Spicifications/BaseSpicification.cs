﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spicifications
{
    public class BaseSpicification<T> : ISpicification<T>
    {
        public BaseSpicification()
        {
        }

        public BaseSpicification(Expression<Func<T, bool>> criteria)
        {
            this.criteria = criteria;
        }

        public Expression<Func<T, bool>> criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> inlcudeExpression)
        {
            Includes.Add(inlcudeExpression);
        }
    }
}
