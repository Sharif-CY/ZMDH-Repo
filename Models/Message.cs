using System;

namespace WDPR.Models{

    public class Message {

        public int ChatId { get; set; }
        public Chat Chat { get; set; }   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }


    }
}