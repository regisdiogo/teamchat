using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeamChat.Core.Interfaces.Repository;
using TeamChat.Core.Interfaces.Service;
using TeamChat.Core.Model;

namespace TeamChat.Service
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> Filter(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.Filter(predicate);
        }

        public User FindById(int id)
        {
            return Filter(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> List()
        {
            return _userRepository.List();
        }

        public void Saves(User model)
        {
            if (model.Id > 0)
                _userRepository.Update(model);
            else
                _userRepository.Insert(model);
        }
    }
}
