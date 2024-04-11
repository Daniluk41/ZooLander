using System.Collections.Generic;

namespace ZooLander
{
    // Класс для представления билета
    class Ticket
    {
        public enum TicketType { Adult, Child, Discounted }
        public TicketType Type { get; set; }
        public double Price { get; set; }
    }
}