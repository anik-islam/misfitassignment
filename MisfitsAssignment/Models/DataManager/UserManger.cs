using MisfitsAssignment.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisfitsAssignment.Models.DataManager
{
    public class UserManger : IUserDataRepository<User>
    {
        readonly UserContext _userContext;
        public UserManger(UserContext context)
        {
            _userContext = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _userContext.User.ToList();
        }

        public User Get(int id)
        {
            return _userContext.User
                  .FirstOrDefault(e => e.ID == id);
        }
        public User Get(string UserId)
        {
            return _userContext.User
                  .FirstOrDefault(e => e.UserID == UserId);
        }

        public void Add(User entity)
        {
            entity.EntryDate = DateTime.Now;
            _userContext.User.Add(entity);
            _userContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.UserID = entity.UserID;
            user.EntryDate = entity.EntryDate; 

            _userContext.SaveChanges();
        }

        public void Delete(User employee)
        {
            _userContext.User.Remove(employee);
            _userContext.SaveChanges();
        }
    }
}
