using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WDPR.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Specializatie {get; set;}

        public string Leeftijdsgroep {get; set;}

        public string Omschrijving {get; set;}
    }
}
