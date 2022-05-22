


namespace Domain
{
    public class Person2
    {
        public Person2(int personId, string userName, string sessionId, string password)
        {
            PersonId = personId;
            UserName = userName;
            SessionId = sessionId;
            Password = password;
        }

        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
    }
}
