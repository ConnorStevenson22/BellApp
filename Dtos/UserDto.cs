using System;
namespace  BellApplication.Dtos{
    public record UserDto{
        public Guid id{ get; init; }
        public string fname{ get; init; }
        public string lname{ get; init; }
        public string phone{ get; init; }
        public string email{ get; init; }
        
    }

}