using Microsoft.AspNetCore.Identity;

namespace WDPR.Models
{
    public class Client : IdentityUser
    {
        public string Naam{get; set;}

        public string achterNaam{get; set;}
        public int leeftijd{get; set;}

    }
}