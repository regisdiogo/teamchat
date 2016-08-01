using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeamChat.Core.Interfaces.Repository;
using TeamChat.Core.Model;
using TeamChat.Repository;
using TeamChat.Repository.Context;

namespace TeamChat.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly TeamChatDbContext _teamChatDbContext;

        public UserRepository(TeamChatDbContext teamChatDbContext)
        {
            _teamChatDbContext = teamChatDbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Filter(Expression<Func<User, bool>> predicate)
        {
            return _teamChatDbContext.Users.Where(predicate);
        }

        public void Insert(User model)
        {
            _teamChatDbContext.Users.Add(model);
            _teamChatDbContext.SaveChanges();
        }

        public IEnumerable<User> List()
        {
            return _teamChatDbContext.Users.AsEnumerable();
        }

        public void Update(User model)
        {
            _teamChatDbContext.Users.Update(model);
            _teamChatDbContext.SaveChanges();
        }
    }
}
