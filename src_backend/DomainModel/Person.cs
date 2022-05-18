

namespace Domain.People
{


    public class Person
    {
        public Person(int idPerson, string userName, string email, string mobileNumber, string password)
        {
            this.idPerson = idPerson;
            this.userName = userName;
            this.email = email;
            this.mobileNumber = mobileNumber;
            this.password = password;
        }

        public int idPerson { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? mobileNumber { get; set; }


    }
}

