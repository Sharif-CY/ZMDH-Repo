using System;
using Microsoft.AspNetCore.Identity;

namespace WDPR.Models
{
    public class Hulpverlener: IdentityUser
    {
        public string VoorNaam { get; set; }
        public string achterNaam { get; set; }
        public string Specialisme {get; set;}
        public string Gebruikersnaam {get; set;}
        public string Telefoonnummer {get; set;}
        public string ProfielFoto {get; set;}
        public string WiebenIk {get; set;}
        public string MijnSTudie {get; set;}
        public string WatAls {get; set;}
        public string HoeHelpen {get; set;}

    }
}
