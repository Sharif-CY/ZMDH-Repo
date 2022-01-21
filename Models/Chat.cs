using System.Collections.Generic;

namespace WDPR.Models{

    public class Chat{


        public Chat(){

        Messages = new List<Message>();

    }
        public ICollection<Message> Messages { get; set; }
    }
}