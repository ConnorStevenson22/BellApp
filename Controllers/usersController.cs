using Microsoft.AspNetCore.Mvc;
using BellApplication.Repos;
using BellApplication.Entities;
using BellApplication.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;



namespace BellApplication.Controllers{

    [ApiController]
    [Route("users")]
    public class UsersController :ControllerBase{
        private readonly IUsersRepo repo;

        public UsersController( IUsersRepo repo){
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetUsers(){
            var Users = repo.GetUsers().Select(
                User => User.asDto());
            return Users;
        }
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(Guid id){
            var user = repo.GetUser(id);

            if(user is null){return NotFound();}
            return user.asDto();
        }
        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto userDto){
            User user = new(){
                id = Guid.NewGuid(),
                fname = userDto.fname,
                lname = userDto.lname,
                phone = userDto.phone,
                email = userDto.email,
                DOB = userDto.DOB,
                address = userDto.address
            };

            repo.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new{ id = user.id},user.asDto());
        }
    }

    

}