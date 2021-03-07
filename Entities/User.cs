using System;

namespace BellApplication.Entities
{
    public record User{
        public Guid id{ get; init; }
        public string fname{ get; init; }
        public string lname{ get; init; }
        public string phone{ get; init; }
        public string email{ get; init; }
        
        public String toString(){
            return fname+","+lname+","+phone+","+email+","+id;
        }
    }
}