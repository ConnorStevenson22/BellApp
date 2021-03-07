using System.ComponentModel.DataAnnotations;

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
        
    }
}