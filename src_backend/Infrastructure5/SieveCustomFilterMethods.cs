using Infrastructure5.EFModel;
using Sieve.Services;

namespace Infrastructure5
{
  public class SieveCustomFilterMethods : ISieveCustomFilterMethods
  {
    /// <summary>
    /// Apply filter to get only those projects withouot choosen people
    /// </summary>
    /// <param name="source"></param>
    /// <param name="op"></param>
    /// <param name="values">list of personIds</param>
    /// <returns></returns>
    public IQueryable<Person> WithoutPersons(IQueryable<Person> source, string op, string[] values)
    {
      if (values != null)
      {
        foreach (string value in values)
        {
          int personId = int.Parse(value);
         // source = source.Where(p => !p.PersonRoles.Any(pr => pr.PersonId == personId));
        }
      }
      return source;
    }

    /// <summary>
    /// Used to filter people such that only projects' non-members are included
    /// </summary>
    /// <param name="source"></param>
    /// <param name="op"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public IQueryable<Person> NotInProjects(IQueryable<Person> source, string op, string[] values)
    {
      if (values != null)
      {
        
      }
      return source;
    }
  }
}
