using System;

namespace BellApplication.Entities
{
    public record User{
        public Guid id{ get; init; }
        public string fname{ get; init; }
        public string lname{ get; init; }
        public string phone{ get; init; }
        public string email{ get; init; }
        public DateTime DOB{ get; init;}
        public string address{ get; init;}

        public String toString(){
            return fname+"|"+lname+"|"+phone+"|"+email+"|"+DOB.ToString()+"|"+address+ "|"+id;
        }

        public static User Parse(string s){
            string[] splitdata = s.Split('|');
            return new User{ fname = splitdata[0],
                                    lname = splitdata[1],
                                    phone = splitdata[2],
                                    email = splitdata[3],
                                    DOB = DateTime.Parse(splitdata[4]),
                                    address = splitdata[5],
                                    id = Guid.Parse(splitdata[6])};
        }

    }
}