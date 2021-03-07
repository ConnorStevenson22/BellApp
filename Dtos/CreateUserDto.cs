using System.ComponentModel.DataAnnotations;
using System;

namespace  BellApplication.Dtos{
     public record CreateUserDto{
        [Required]
        public string fname{ get; init; }
        [Required]
        public string lname{ get; init; }
        [Required]
        public string phone{ get; init; }
        [Required]
        public string email{ get; init; }
        [Required]
        public DateTime DOB{ get; init; }
        [Required]
        public string address{ get; init; }
        
    }
}