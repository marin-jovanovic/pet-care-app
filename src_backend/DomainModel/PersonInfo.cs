

namespace Domain.People
{

    public record PersonInfo(int PersonId, string userName)
    {
        public string PersonFullName => $"{userName}";
    }
}
