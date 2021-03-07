using BellApplication.Dtos;
using BellApplication.Entities;

namespace BellApplication{
    public static class Extensions{
        public static UserDto asDto(this User user){
            return new UserDto {
                    id=user.id,
                    fname=user.fname,
                    lname=user.lname,
                    email=user.email,
                    phone=user.phone
                };
        }
        
    }

}