using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Spicifications;
using Microsoft.EntityFrameworkCore;
namespace Infrastucture.Data
{
    internal class SpicificationEvaluater<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,  ISpicification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.criteria != null)
            {
                query = query.Where(spec.criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
