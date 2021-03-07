using System.Collections.Generic;
using System;
using System.Linq;
using BellApplication.Entities;
using BellApplication.Data;

namespace BellApplication.Repos{
    public class DbUsersRepo : IUsersRepo{


        public IEnumerable<User> GetUsers(){
            return UserDbStorageClient.GetInstance().getUsers();
        }

        public void CreateUser(User user){
            UserDbStorageClient.GetInstance().WriteUser(user);
        }

        public User GetUser(Guid id){
            
            return UserDbStorageClient.GetInstance().getUsers().Where(user => user.id == id).SingleOrDefault();
        }
    }
}
