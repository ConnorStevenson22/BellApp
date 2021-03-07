using System;
using System.IO;
using System.Collections.Generic;
using BellApplication.Entities;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;



namespace BellApplication.Data{
    public class UserDbStorageClient{
        private string DbName;
        private string TbName;
        private SqlConnection activeConnection;

        public UserDbStorageClient(string DbName,String TbName){
            this.DbName = DbName;
            this.TbName = TbName;
            string connectionString = @"Data Source=DESKTOP-H9QDJ5O\SQLEXPRESS;Initial Catalog="+DbName+";User ID=admin;Password=password";
            activeConnection = new SqlConnection(connectionString);
            activeConnection.Open();
            _instance = this;

        }
        public void WriteUser(User user){
           SqlCommand command;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string sql;
            List<User> users = new();

            sql = "Insert into "+TbName+"(id,fname,lname,phone,email) values('"
                +user.id+"','"
                +user.fname+"','"
                +user.lname+"','"
                +user.phone+"','"
                +user.email
                +"')";
            command = new SqlCommand(sql,activeConnection);
            dataAdapter.InsertCommand = command;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            dataAdapter.Dispose();
            command.Dispose();
        }

        public List<User> getUsers(){
            
            SqlCommand command;
            SqlDataReader dataReader;
            string sql;
            List<User> users = new();

            sql = "select id,fname,lname,phone,email from "+TbName;
            command = new SqlCommand(sql,activeConnection);
            dataReader = command.ExecuteReader();
            while(dataReader.Read()){ 
                users.Add(new(){
                    id = Guid.Parse(dataReader.GetString(0)),
                    fname = dataReader.GetString(1),
                    lname = dataReader.GetString(2),
                    phone = dataReader.GetString(3),
                    email = dataReader.GetString(4)
                });
            }
            dataReader.Close();
            command.Dispose();
            return users;
        }
        
        private static UserDbStorageClient _instance;
        public static UserDbStorageClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserDbStorageClient("","");
            }
            return _instance;
        }
       

    }
}