using System;
using System.IO;
using System.Collections.Generic;
using BellApplication.Entities;

namespace BellApplication.Data{
    public class UserFileStorageClient{
        private string path;
        private string FileName;

        public UserFileStorageClient(string path,string FileName){
            this.path = path;
            this.FileName = FileName;
            string pathString = Path.Combine(path, FileName);
            if (!File.Exists(pathString))
            {
                File.Create(pathString); 
            }
            _instance = this;

        }
        public void WriteUser(User user){
            string pathString = Path.Combine(path, FileName);
            using StreamWriter file = new(pathString, append: true);
            file.WriteLine(user.toString());
        }

        public List<User> getUsers(){
            List<User> users = new();
            string pathString = Path.Combine(path, FileName);
            string[] lines = File.ReadAllLines(pathString);
            foreach(string line in lines){
                
                users.Add(User.Parse(line));
                
            }
            return users;
        }
        private static UserFileStorageClient _instance;
        public static UserFileStorageClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserFileStorageClient("","");
            }
            return _instance;
        }
    }
}