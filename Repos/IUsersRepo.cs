using System.Collections.Generic;
using System;
using BellApplication.Entities;

namespace BellApplication.Repos{
    public interface IUsersRepo
    {
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
    }
}