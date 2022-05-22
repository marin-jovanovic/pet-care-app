using System.ComponentModel.DataAnnotations;

namespace PetCareAppMVC.Features.Listings;

public class SessionViewModel
{
    //public SessionViewModel(string sessionId)
    //{
    //    this.sessionId = sessionId;
    //}

    public string sessionId { get; set; }
    public string UserName { get; set; }


}
