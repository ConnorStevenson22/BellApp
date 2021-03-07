using System.Collections.Generic;
using System;
using System.Linq;
using BellApplication.Entities;

namespace BellApplication.Repos{

    public class UsersRepo : IUsersRepo
    {
        private readonly List<User> users = new()
        {

        };
        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public void CreateUser(User user){
            users.Add(user);
        }

        public User GetUser(Guid id)
        {
            return users.Where(user => user.id == id).SingleOrDefault();

        }
    }

}