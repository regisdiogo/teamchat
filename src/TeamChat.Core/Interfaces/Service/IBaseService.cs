using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TeamChat.Core.Interfaces.Service
{
    public interface IBaseService<M>
    {
        void Saves(M model);

        IEnumerable<M> List();

        IEnumerable<M> Filter(Expression<Func<M, bool>> predicate);

        M FindById(int id);

        void Delete(int id);
    }
}
