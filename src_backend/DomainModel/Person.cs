

namespace Domain.People
{


    public class Person
    {
        public Person(int personId, string personFirstName, string userName, string personEmail, string personLastName, string password, string personMobile, string sessionId)
        {
            PersonId = personId;
            PersonFirstName = personFirstName;
            UserName = userName;
            PersonEmail = personEmail;
            PersonLastName = personLastName;
            Password = password;
            PersonMobile = personMobile;
            SessionId = sessionId;
        }

        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string Oib { get; set; }
        public string PersonEmail { get; set; }
        public string PersonMobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }


    }
}

