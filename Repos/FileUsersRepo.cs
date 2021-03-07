using System.Collections.Generic;
using System;
using System.Linq;
using BellApplication.Entities;
using BellApplication.Data;

namespace BellApplication.Repos{
    public class FileUsersRepo : IUsersRepo{


        public IEnumerable<User> GetUsers(){
            return UserFileStorageClient.GetInstance().getUsers();
        }

        public void CreateUser(User user){
            UserFileStorageClient.GetInstance().WriteUser(user);
        }

        public User GetUser(Guid id){
            
            return UserFileStorageClient.GetInstance().getUsers().Where(user => user.id == id).SingleOrDefault();
        }
    }
}
