using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spicifications
{
    public interface ISpicification<T>
    {
        public Expression<Func<T, bool>> criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
    }
}
