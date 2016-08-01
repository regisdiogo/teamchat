using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TeamChat.Core.Interfaces.Repository
{
    public interface IBaseRepository<M>
    {
        void Insert(M model);

        void Update(M model);

        IEnumerable<M> List();

        IEnumerable<M> Filter(Expression<Func<M, bool>> predicate);

        void Delete(int id);
    }
}
