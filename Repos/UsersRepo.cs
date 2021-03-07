using System.Collections.Generic;
using System;
using System.Linq;
using BellApplication.Entities;

namespace BellApplication.Repos{

    public class UsersRepo : IUsersRepo
    {
        private readonly List<User> users = new()
        {
            new User
            {
                id = Guid.NewGuid(),
                fname = "asd",
                lname = "dsa",
                email = "email@asd.com",
                phone = "1233333333"
            }
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