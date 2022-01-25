using Microsoft.AspNetCore.Identity;

namespace WDPR.Models
{
    public class Ouder : IdentityUser
    {
        public string Naam{get; set;}

        public string achterNaam{get; set;}

        public string HoortBijKind{get; set;}

    }
}