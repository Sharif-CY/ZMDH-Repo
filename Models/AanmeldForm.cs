using System;

namespace WDPR.Models
{
    public class AanmeldForm
    {
        public int ID{get; set;}
        public string VoorNaam { get; set; }
        public string achterNaam { get; set; }
        public DateTime Geboortedatum {get;set;}
        public string Aandoening {get; set;}
        public string Email {get; set;}
        public string Orthopedagoog {get; set;}

    }
}
